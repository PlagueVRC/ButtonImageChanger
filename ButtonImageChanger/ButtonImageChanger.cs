using LoadSprite;
using MelonLoader;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(ButtonImageChanger.ButtonImageChanger), "Button Image Changer", "", "Viola Layne & Plague", null)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace ButtonImageChanger
{
    public class ButtonImageChanger : MelonMod
    {
        internal Sprite ButtonBackground = null;

        public override void OnApplicationStart()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\ButtonBackground.png"))
            {
                ButtonBackground = (Environment.CurrentDirectory + "\\ButtonBackground.png").LoadSpriteFromDisk();
            }
            else
            {
                MelonLogger.LogError("Could Not Find ButtonBackground.png - UI Not Edited As A Result!");
            }
        }

        public override void VRChat_OnUiManagerInit()
        {
            if (ButtonBackground != null)
            {
                #region Object Toggling

                GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_Background/Panel").GetComponent<Image>().enabled = false;
                GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_InfoBar/Panel").GetComponent<Image>().enabled = false;

                GameObject ContextArea = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements/_CONTEXT");

                var Images = ContextArea.GetComponentsInChildren<Image>(true);

                for (int i = 0; i < Images.Count; i++)
                {
                    var Image = Images[i];

                    if (Image.transform.name.Contains("Panel") || Image.transform.name.Contains("UserStatus") || Image.transform.name.Contains("UserBio"))
                    {
                        Image.enabled = false;
                    }
                }

                #endregion

                #region OCD

                GameObject.Find("UserInterface/QuickMenu/MicControls/MicButton").transform.localPosition = new Vector3(-1.500f, 142.000f, 0.000f);

                #endregion

                #region Manual Changes

                GameObject.Find("UserInterface/QuickMenu/UserInteractMenu/FriendButton").GetComponent<Image>().sprite =
                    ButtonBackground;

                #endregion

                #region Automated Changes

                Sprite StandardSprite = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/SettingsButton").GetComponent<Image>().sprite;

                if (StandardSprite != null)
                {
                    var Buttons = GameObject.Find("UserInterface/QuickMenu").GetComponentsInChildren<Button>(true);

                    if (Buttons != null && Buttons.Count > 0)
                    {
                        for (int i = 0; i < Buttons.Count; i++)
                        {
                            Button button = Buttons[i];

                            if (button != null)
                            {
                                //Button Is Not A Toggle Button
                                if (button.GetComponent<UiToggleButton>() == null)
                                {
                                    if (button.GetComponentInChildren<UiToggleButton>(true) == null)
                                    {
                                        Image image = button.gameObject.GetComponent<Image>();

                                        if (image != null && image.sprite != null)
                                        {
                                            //If Wasn't Previously Changed
                                            if (image.sprite != ButtonBackground)
                                            {
                                                //If Is Not A Custom Background Image
                                                if (image.sprite == StandardSprite)
                                                {
                                                    image.sprite = ButtonBackground;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Image MainToggleImage = button.gameObject.GetComponent<Image>();

                                        if (MainToggleImage != null && MainToggleImage.sprite != null)
                                        {
                                            //If Wasn't Previously Changed
                                            if (MainToggleImage.sprite != ButtonBackground)
                                            {
                                                //If Is Not A Custom Background Image
                                                if (MainToggleImage.sprite == StandardSprite)
                                                {
                                                    MainToggleImage.sprite = ButtonBackground;
                                                }
                                            }
                                        }

                                        for (int i2 = 0; i2 < button.transform.childCount; i2++)
                                        {
                                            Transform trans = button.transform.GetChild(i2);

                                            if (trans != null)
                                            {
                                                Transform ON = trans.Find("ON");
                                                Transform OFF = trans.Find("OFF");

                                                if (ON != null)
                                                {
                                                    Image image = ON.GetComponent<Image>();

                                                    if (image != null && image.sprite != null)
                                                    {
                                                        //If Wasn't Previously Changed
                                                        if (image.sprite != ButtonBackground)
                                                        {
                                                            image.sprite = ButtonBackground;
                                                        }
                                                    }
                                                }

                                                if (OFF != null)
                                                {
                                                    Image image = OFF.GetComponent<Image>();

                                                    if (image != null && image.sprite != null)
                                                    {
                                                        //If Wasn't Previously Changed
                                                        if (image.sprite != ButtonBackground)
                                                        {
                                                            image.sprite = ButtonBackground;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Image MainToggleImage = button.gameObject.GetComponent<Image>();

                                    if (MainToggleImage != null && MainToggleImage.sprite != null)
                                    {
                                        //If Wasn't Previously Changed
                                        if (MainToggleImage.sprite != ButtonBackground)
                                        {
                                            //If Is Not A Custom Background Image
                                            if (MainToggleImage.sprite == StandardSprite)
                                            {
                                                MainToggleImage.sprite = ButtonBackground;
                                            }
                                        }
                                    }

                                    for (int i2 = 0; i2 < button.transform.childCount; i2++)
                                    {
                                        Transform trans = button.transform.GetChild(i2);

                                        if (trans != null)
                                        {
                                            Transform ON = trans.Find("ON");
                                            Transform OFF = trans.Find("OFF");

                                            if (ON != null)
                                            {
                                                Image image = ON.GetComponent<Image>();

                                                if (image != null && image.sprite != null)
                                                {
                                                    //If Wasn't Previously Changed
                                                    if (image.sprite != ButtonBackground)
                                                    {
                                                        image.sprite = ButtonBackground;
                                                    }
                                                }
                                            }

                                            if (OFF != null)
                                            {
                                                Image image = OFF.GetComponent<Image>();

                                                if (image != null && image.sprite != null)
                                                {
                                                    //If Wasn't Previously Changed
                                                    if (image.sprite != ButtonBackground)
                                                    {
                                                        image.sprite = ButtonBackground;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MelonLogger.LogError("Could Not Find Buttons To Change Sprites Of!");
                    }
                }
                else
                {
                    MelonLogger.LogError("Could Not Find Settings Button For StandardSprite!");
                }

                #endregion
            }
        }
    }
}
