using SimpleFileIO.State.Ini;
using SimpleFileIO.Utility;
using SimpleOverlayTheme.Object.BorderObject.Helper;
using SimpleOverlayTheme.Theme.ThemeProperty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleOverlayTheme.Theme.Interface
{
    public abstract class ATheme : ITheme
    {
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Identity ==========

        /// <summary>  Gets or sets the name of the theme.</summary>
        public override string ThemeName { get; abs set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Font Sizes ==========

        /// <summary>Gets or sets the font size for Header1.</summary>
        double FontSize_Header1 { get; set; }

        /// <summary>Gets or sets the font size for Header2.</summary>
        double FontSize_Header2 { get; set; }

        /// <summary>Gets or sets the font size for Header3.</summary>
        double FontSize_Header3 { get; set; }

        /// <summary>Gets or sets the font size for Header4.</summary>
        double FontSize_Header4 { get; set; }

        /// <summary>Gets or sets the font size for Header5.</summary>
        double FontSize_Header5 { get; set; }

        /// <summary>Gets or sets the font size for Header6.</summary>
        double FontSize_Header6 { get; set; }

        /// <summary>Gets or sets the default body font size.</summary>
        double FontSize_Default { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Thickness ==========

        /// <summary>Gets or sets the default UI element thickness.</summary>
        Thickness Thickness_Default { get; set; }

        /// <summary>Gets or sets zero-thickness, often used for spacing removal.</summary>
        Thickness Thickness_Zero { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Color Palette ==========

        /// <summary>Main foreground color.</summary>
        Color ColorPalette_Foreground { get; set; }

        /// <summary>Foreground color when disabled.</summary>
        Color ColorPalette_Foreground_Disable { get; set; }

        /// <summary>Main background color.</summary>
        Color ColorPalette_Background { get; set; }

        /// <summary>Outline color used for borders and frames.</summary>
        Color ColorPalette_Outline { get; set; }

        /// <summary>Line color, typically used for underlines or separators.</summary>
        Color ColorPalette_Line { get; set; }

        /// <summary>Highlight color used for hover or active indication.</summary>
        Color ColorPalette_Highlight { get; set; }

        /// <summary>Selection background color.</summary>
        Color ColorPalette_Selection { get; set; }

        /// <summary>Mask or overlay tint color, often semi-transparent.</summary>
        Color ColorPalette_Mask { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Border Background ==========

        /// <summary>Overlay border background when disabled.</summary>
        Color OverlayBorderBackground_Disable { get; set; }

        /// <summary>Overlay border background in default state.</summary>
        Color OverlayBorderBackground_Default { get; set; }

        /// <summary>Overlay border background on mouse-over.</summary>
        Color OverlayBorderBackground_MouseOver { get; set; }

        /// <summary>Overlay border background when active.</summary>
        Color OverlayBorderBackground_Active { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Interface - Border Outline ==========

        /// <summary>Overlay border outline when disabled.</summary>
        Color OverlayBorderOutline_Disable { get; set; }

        /// <summary>Overlay border outline in default state.</summary>
        Color OverlayBorderOutline_Default { get; set; }

        /// <summary>Overlay border outline on mouse-over.</summary>
        Color OverlayBorderOutline_MouseOver { get; set; }

        /// <summary>Overlay border outline when active.</summary>
        Color OverlayBorderOutline_Active { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== Overlay - Mask Foreground ==========

        /// <summary>Overlay mask foreground when disabled.</summary>
        Color OverlayMaskForeground_Disable { get; set; }

        /// <summary>Overlay mask foreground in default state.</summary>
        Color OverlayMaskForeground_Default { get; set; }

        /// <summary>Overlay mask foreground on mouse-over.</summary>
        Color OverlayMaskForeground_MouseOver { get; set; }

        /// <summary>Overlay mask foreground when active.</summary>
        Color OverlayMaskForeground_Active { get; set; }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== INI File Interaction ==========

        /// <summary>
        /// Saves the current theme settings to the associated INI file.
        /// </summary>
        /// <returns>True if save operation was successful; otherwise, false.</returns>
        bool SaveToFile();

        /// <summary>
        /// Loads theme settings from the associated INI file and applies them to the current object.
        /// </summary>
        /// <returns>True if loading and application were successful; otherwise, false.</returns>
        bool LoadFromFile();

        /// <summary>
        /// Deletes the INI file associated with this theme instance.
        /// </summary>
        /// <returns>True if the file was deleted successfully; otherwise, false.</returns>
        bool DeleteFile();

        #endregion
        ////////////////////////////////////////////////////////////////////////////////
        //                                                                            //
        ////////////////////////////////////////////////////////////////////////////////
        #region ========== INI State Interaction ==========

        /// <summary>
        /// Applies values from a preloaded INI state to the in-memory properties.<br/>
        /// This does not involve file access and assumes the INI was already loaded.
        /// </summary>
        /// <returns>True if apply succeeded; otherwise, false.</returns>
        bool Apply();

        /// <summary>
        /// Restores current values into a temporary INI memory structure.<br/>
        /// This is used for preparing save operations, but does not write to file.
        /// </summary>
        /// <returns>True if restore succeeded; otherwise, false.</returns>
        bool Restore();

        /// <summary>
        /// Resets all values in this theme to their predefined default values.
        /// </summary>
        void ResetValueToDefault();

        #endregion





        private readonly IINIState _iniFile;
        private readonly Dictionary<string, IThemeProperty> _themeProperties;

        private CommonThemeProperty _common;
        private OverlayThemeProperty _overlay;

        // Name
        private protected string ThemeName { get => _common.ThemeName.Value; set => _common.ThemeName.Value = value; }

        // FontSize
        private protected double FontSize_Header1 { get => _common.FontSize_Header1.Value; set => _common.FontSize_Header1.Value = value; }
        private protected double FontSize_Header2 { get => _common.FontSize_Header2.Value; set => _common.FontSize_Header2.Value = value; }
        private protected double FontSize_Header3 { get => _common.FontSize_Header3.Value; set => _common.FontSize_Header3.Value = value; }
        private protected double FontSize_Header4 { get => _common.FontSize_Header4.Value; set => _common.FontSize_Header4.Value = value; }
        private protected double FontSize_Header5 { get => _common.FontSize_Header5.Value; set => _common.FontSize_Header5.Value = value; }
        private protected double FontSize_Header6 { get => _common.FontSize_Header6.Value; set => _common.FontSize_Header6.Value = value; }
        private protected double FontSize_Default { get => _common.FontSize_Default.Value; set => _common.FontSize_Default.Value = value; }

        // Thickness
        private protected Thickness Thickness_Default { get => _common.Thickness_Default.Value; set => _common.Thickness_Default.Value = value; }
        private protected Thickness Thickness_Zero { get => _common.Thickness_Zero.Value; set => _common.Thickness_Zero.Value = value; }

        // ColorPalette
        private protected Color ColorPalette_Foreground { get => _common.ColorPalette_Foreground.Value; set => _common.ColorPalette_Foreground.Value = value; }
        private protected Color ColorPalette_Foreground_Disable { get => _common.ColorPalette_Foreground_Disable.Value; set => _common.ColorPalette_Foreground_Disable.Value = value; }
        private protected Color ColorPalette_Background { get => _common.ColorPalette_Background.Value; set => _common.ColorPalette_Background.Value = value; }
        private protected Color ColorPalette_Outline { get => _common.ColorPalette_Outline.Value; set => _common.ColorPalette_Outline.Value = value; }
        private protected Color ColorPalette_Line { get => _common.ColorPalette_Line.Value; set => _common.ColorPalette_Line.Value = value; }
        private protected Color ColorPalette_Highlight { get => _common.ColorPalette_Highlight.Value; set => _common.ColorPalette_Highlight.Value = value; }
        private protected Color ColorPalette_Selection { get => _common.ColorPalette_Selection.Value; set => _common.ColorPalette_Selection.Value = value; }
        private protected Color ColorPalette_Mask { get => _common.ColorPalette_Mask.Value; set => _common.ColorPalette_Mask.Value = value; }

        // Overlay Border Background
        private protected Color OverlayBorderBackground_Disable { get => _overlay.BorderBackground_Disable.Value; set => _overlay.BorderBackground_Disable.Value = value; }
        private protected Color OverlayBorderBackground_Default { get => _overlay.BorderBackground_Default.Value; set => _overlay.BorderBackground_Default.Value = value; }
        private protected Color OverlayBorderBackground_MouseOver { get => _overlay.BorderBackground_MouseOver.Value; set => _overlay.BorderBackground_MouseOver.Value = value; }
        private protected Color OverlayBorderBackground_Active { get => _overlay.BorderBackground_Active.Value; set => _overlay.BorderBackground_Active.Value = value; }

        // Overlay Border Outline
        private protected Color OverlayBorderOutline_Disable { get => _overlay.BorderOutline_Disable.Value; set => _overlay.BorderOutline_Disable.Value = value; }
        private protected Color OverlayBorderOutline_Default { get => _overlay.BorderOutline_Default.Value; set => _overlay.BorderOutline_Default.Value = value; }
        private protected Color OverlayBorderOutline_MouseOver { get => _overlay.BorderOutline_MouseOver.Value; set => _overlay.BorderOutline_MouseOver.Value = value; }
        private protected Color OverlayBorderOutline_Active { get => _overlay.BorderOutline_Active.Value; set => _overlay.BorderOutline_Active.Value = value; }

        // Overlay Mask Foreground
        private protected Color OverlayMaskForeground_Disable { get => _overlay.MaskForeground_Disable.Value; set => _overlay.MaskForeground_Disable.Value = value; }
        private protected Color OverlayMaskForeground_Default { get => _overlay.MaskForeground_Default.Value; set => _overlay.MaskForeground_Default.Value = value; }
        private protected Color OverlayMaskForeground_MouseOver { get => _overlay.MaskForeground_MouseOver.Value; set => _overlay.MaskForeground_MouseOver.Value = value; }
        private protected Color OverlayMaskForeground_Active { get => _overlay.MaskForeground_Active.Value; set => _overlay.MaskForeground_Active.Value = value; }

        /// <summary>
        /// 지정된 이름의 테마 객체를 초기화하고, INI 파일 상태를 구성합니다.
        /// </summary>
        /// <param name="name">테마 이름</param>
        /// <exception cref="ArgumentNullException">INI 생성 실패 시 예외 발생</exception>
        internal ATheme(string name)
        {
            _common = new();
            _overlay = new();
            _themeProperties = new()
            {
                { nameof(CommonThemeProperty), _common },
                { nameof(OverlayThemeProperty), _overlay },
            };
            _common.ThemeName.Value = name;

            PathProperty pathProperty = new()
            {
                RootDirectory = new("./Theme/Object"),
                FileName = ThemeName,
                Extension = ".ini"
            };
            _iniFile = SimpleFileIO.Manager.CreateIniState($"ThemeObject_{ThemeName}", pathProperty)
                        ?? throw new ArgumentNullException($"Not make ThemeObject_{ThemeName}.");

            IniFileSetting();
        }

        /// <summary>
        /// 현재 값을 INI 상태에 저장하고 파일로 저장합니다.
        /// </summary>
        /// <returns>성공 여부</returns>
        public bool Save()
        {
            if (_iniFile is null)
                return false;
            return SyncTo(_iniFile) && _iniFile.Save();
        }

        /// <summary>
        /// INI 파일을 로드한 뒤, 현재 설정에 반영합니다.
        /// </summary>
        /// <returns>성공 여부</returns>
        public bool Load()
        {
            if (_iniFile is null)
                return false;
            return _iniFile.Load() && SyncFrom(_iniFile);
        }

        /// <summary>
        /// 연결된 INI 파일을 삭제합니다.
        /// </summary>
        /// <returns>삭제 성공 여부</returns>
        internal bool DeleteFile()
        {
            var pathProperty = _iniFile.PathProperty;
            string fullPath = Path.Combine(pathProperty.RootDirectory.FullName, $"{pathProperty.FileName}.{pathProperty.Extension}");
            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new IOException($"[DeleteFile] File Delete Fail: '{fullPath}'", ex);
                }
            }
            return false;
        }

        public bool SyncTo(IINIState? iniFile) => SyncTo_Private(iniFile);

        public bool SyncFrom(IINIState? iniFile) => SyncFrom_Private(iniFile);

        public void ResetToDefault() => ResetToDefault_Private();



        private bool SyncTo_Private(IINIState? iniFile)
        {
            if (_themeProperties is null)
                return false;
            try
            {
                return _themeProperties.AsParallel().All(x => x.Value.SyncTo(iniFile));
            }
            catch (NotSupportedException)
            {
                return _themeProperties.All(x => x.Value.SyncTo(iniFile)); // Fallback
            }
        }
        private bool SyncFrom_Private(IINIState? iniFile)
        {
            if (_themeProperties is null)
                return false;
            try
            {
                return _themeProperties.AsParallel().All(x => x.Value.SyncFrom(iniFile));
            }
            catch (NotSupportedException)
            {
                return _themeProperties.All(x => x.Value.SyncFrom(iniFile)); // Fallback
            }
        }

        private void ResetToDefault_Private()
        {
            if (_themeProperties is null)
                return;
            try
            {
                _themeProperties.AsParallel().ForAll(x => x.Value.ResetToDefault());
            }
            catch (NotSupportedException)
            {
                _themeProperties.Values.ToList().ForEach(x => x.ResetToDefault()); // Fallback
            }
        }

        private void IniFileSetting()
        {
            // Color 형식 전용 파서 등록
            StringTypeParser colorStringTypeParser = new()
            {
                TargetType = typeof(Color),
                ObjectToString = obj => obj is Color color ? $"{color.A},{color.R},{color.G},{color.B}" : "0,0,0,0",
                StringToObject = str =>
                {
                    var strArray = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return strArray.Length switch
                    {
                        3 => Color.FromRgb(byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2])),
                        4 => Color.FromArgb(byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2]), byte.Parse(strArray[3])),
                        _ => Colors.Transparent,
                    };
                }
            };

            _iniFile.AddParser(typeof(Color), colorStringTypeParser);

            var thicknessStringTypeParser = new StringTypeParser
            {
                TargetType = typeof(Thickness),

                ObjectToString = (obj) =>
                {
                    if (obj is Thickness t)
                    {
                        if (t.Left == t.Top && t.Top == t.Right && t.Right == t.Bottom)
                            return $"{t.Left}";
                        else if (t.Left == t.Right && t.Top == t.Bottom)
                            return $"{t.Left},{t.Top}";
                        else
                            return $"{t.Left},{t.Top},{t.Right},{t.Bottom}";
                    }
                    return "0";
                },

                StringToObject = (str) =>
                {
                    var parts = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1 && double.TryParse(parts[0], out double all))
                    {
                        return new Thickness(all);
                    }
                    else if (parts.Length == 2 &&
                             double.TryParse(parts[0], out double h) &&
                             double.TryParse(parts[1], out double v))
                    {
                        return new Thickness(h, v, h, v);
                    }
                    else if (parts.Length == 4 &&
                             double.TryParse(parts[0], out double l) &&
                             double.TryParse(parts[1], out double t) &&
                             double.TryParse(parts[2], out double r) &&
                             double.TryParse(parts[3], out double b))
                    {
                        return new Thickness(l, t, r, b);
                    }

                    return new Thickness(0);
                }
            };

            _iniFile.AddParser(typeof(Thickness), thicknessStringTypeParser);
        }
    }
}
