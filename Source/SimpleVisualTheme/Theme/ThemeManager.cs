// SimpleVisualTheme/Theme/ThemeManager.cs
using SimpleVisualTheme.Theme.Current;
using SimpleVisualTheme.Theme.Data;
using SimpleVisualTheme.Theme.Data.Internal;
using System;
using System.Collections.Generic; // For Task.Run
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleVisualTheme.Theme
{
    public class ThemeManager
    {
        // Singleton Instance
        public static ThemeManager Instance { get; } = new ThemeManager();
        private ThemeManager() {
            ThemeDataGroup.Instance.DataRootPath = new("./Theme");
            DiscoverThemeData();
            Current.Current.Instance.ThemeName = "Current";
        }


        public List<string> ChangedProperty()
        {
            List<string> list = new();

            var current = ThemeDataGroup.Instance.GetData("Current");
            if (current is null)
            {
                return list;
            }

            var keys = current.PropertyKeys();
            foreach (var key in keys)
            {
                var property = current.GetProperty(key);

                if (property is null)
                {
                    continue;
                }

                if (ThemeResourceDictionary.Instance[property.XamlKey].ToString() != property.Value)
                {
                    list.Add(property.XamlKey);
                }
            }
            return list;
        }


        public void DiscoverThemeData()
        {
            ThemeDataGroup.Instance.DataRootPath = new("./Theme");
            ThemeDataGroup.Instance.DiscoverData();

        }

        public T? GetThemeProperty<T>(string propertyName)
        {
            return ThemeResourceDictionary.Instance.GetThemeProperty<T>(propertyName);
        }
        //private string _currentThemeName = "Default"; // 현재 적용된 테마 이름
        //public string CurrentThemeName
        //{
        //    get => _currentThemeName;
        //    private set
        //    {
        //        if (_currentThemeName != value)
        //        {
        //            _currentThemeName = value;
        //            // 테마 변경 알림 (필요 시)
        //            // ThemeChanged?.Invoke(this, new ThemeChangedEventArgs(_currentThemeName));
        //        }
        //    }
        //}

        //// 테마를 적용하는 핵심 메서드
        //public async Task ApplyThemeAsync(string themeName)
        //{
        //    // 백그라운드 스레드에서 데이터 로드 및 ResourceDictionary 생성
        //    // 이는 UI 스레드를 블로킹하지 않습니다.
        //    await Task.Run(() =>
        //    {
        //        IThemeData? themeData = ThemeDataGroup.Instance.GetData(themeName);
        //        if (themeData == null)
        //        {
        //            // 예외 처리 또는 기본 테마 로드
        //            throw new ArgumentException($"Theme data for '{themeName}' not found.");
        //        }

        //        // 1. 새로운 ResourceDictionary 생성
        //        // 이 ResourceDictionary는 UI 스레드에서만 접근 가능하므로,
        //        // 여기서 생성하더라도 UI 스레드로 넘겨서 사용해야 합니다.
        //        // 그러나 ResourceDictionary 자체는 UIElement가 아니므로 생성은 백그라운드 스레드에서 가능합니다.
        //        ResourceDictionary newThemeDictionary = CreateResourceDictionaryFromThemeData(themeData);

        //        // 2. UI 스레드에서 Application.Current.Resources 업데이트
        //        // Dispatcher를 사용하여 UI 스레드로 작업을 마샬링합니다.
        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            // 기존 테마 ResourceDictionary 제거 (테마 교체 시)
        //            // 기존 ResourceDictionary를 찾아서 제거하는 로직이 필요합니다.
        //            // 예시에서는 MergedDictionaries에서 제거하는 방식.
        //            RemoveExistingThemeDictionaries(Application.Current.Resources.MergedDictionaries);

        //            // 새로운 ResourceDictionary 추가
        //            Application.Current.Resources.MergedDictionaries.Add(newThemeDictionary);

        //            CurrentThemeName = themeName; // 현재 테마 이름 업데이트
        //        });
        //    });
        //}

        //// 초기 테마 로드 및 시스템 초기화
        //public async Task InitializeThemeSystem(string initialThemeName = "Default", DirectoryInfo? dataRootPath = null)
        //{
        //    if (dataRootPath != null)
        //    {
        //        ThemeDataGroup.Instance.DataRootPath = dataRootPath;
        //    }

        //    // 데이터 검색 및 기본값 설정 (비동기)
        //    await Task.Run(() =>
        //    {
        //        try
        //        {
        //            ThemeDataGroup.Instance.DiscoverData();
        //            // 만약 DiscoverData 후에도 원하는 테마가 없다면 기본 테마를 생성
        //            if (!ThemeDataGroup.Instance.DataKeys().Contains(initialThemeName))
        //            {
        //                ThemeDataGroup.Instance.SetDataToDefault(); // Light, Dark, Current 등을 생성
        //                ThemeDataGroup.Instance.SaveDataAll(); // 생성된 기본 테마를 저장
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // 로깅 또는 사용자에게 알림
        //            Console.WriteLine($"Error during theme data discovery/initialization: {ex.Message}");
        //            // 최소한의 동작을 위해 기본 테마를 강제로 생성 시도
        //            ThemeDataGroup.Instance.SetDataToDefault();
        //            ThemeDataGroup.Instance.SaveDataAll();
        //        }
        //    });

        //    // 초기 테마 적용 (UI 스레드에서)
        //    await ApplyThemeAsync(initialThemeName);
        //}


        //// ThemeData를 기반으로 ResourceDictionary를 동적으로 생성하는 내부 메서드
        //private ResourceDictionary CreateResourceDictionaryFromThemeData(IThemeData themeData)
        //{
        //    ResourceDictionary dict = new ResourceDictionary();

        //    foreach (var key in themeData.PropertyKeys())
        //    {
        //        var prop = themeData.GetPropertyNullThrow(key);
        //        object? value = null;

        //        try
        //        {
        //            // XamlKey는 WPF에서 사용하는 Resource Key가 됩니다.
        //            // Value는 string이므로 적절한 타입으로 변환해야 합니다.
        //            switch (prop.Type)
        //            {
        //                case "Double":
        //                    value = double.Parse(prop.Value);
        //                    break;
        //                case "SolidColorBrush":
        //                    // "#AARRGGBB" 형식의 문자열을 SolidColorBrush로 변환
        //                    value = (SolidColorBrush)new BrushConverter().ConvertFromString(prop.Value)!;
        //                    break;
        //                // 추가적인 타입 변환 로직 (예: Thickness, CornerRadius, String 등)
        //                case "String":
        //                    value = prop.Value;
        //                    break;
        //                // 다른 타입이 있다면 추가
        //                default:
        //                    // 알 수 없는 타입은 문자열로 간주하거나 예외 처리
        //                    Console.WriteLine($"Warning: Unknown theme data type '{prop.Type}' for key '{key}'. Using string value.");
        //                    value = prop.Value;
        //                    break;
        //            }

        //            if (value != null)
        //            {
        //                // XamlKey를 ResourceDictionary의 키로 사용
        //                dict.Add(prop.XamlKey, value);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error converting theme data property '{key}' (Type: {prop.Type}, Value: {prop.Value}): {ex.Message}");
        //            // 오류가 발생해도 나머지 속성은 계속 처리
        //        }
        //    }
        //    return dict;
        //}

        //// 기존 테마 딕셔너리를 제거하는 헬퍼 메서드
        //private void RemoveExistingThemeDictionaries(System.Collections.ObjectModel.Collection<ResourceDictionary> mergedDictionaries)
        //{
        //    // 여기서는 특정 식별자(예: ResourceDictionary에 Tag 속성 추가)를 사용하여
        //    // 이전에 추가된 테마 딕셔너리를 식별하고 제거하는 것이 가장 좋습니다.
        //    // 간단한 예시로, 특정 키를 포함하는 딕셔너리를 제거할 수 있지만,
        //    // 더 견고한 방법을 사용해야 합니다.
        //    // 예를 들어, ResourceDictionary에 CustomKey="ThemeDictionary"와 같은 속성을 추가하고 검색합니다.

        //    // 현재 예시에서는 MergedDictionaries의 마지막에 추가되는 것으로 가정하고 제거합니다.
        //    // 실제 구현에서는 고유한 식별자를 ResourceDictionary에 부여하여 관리하는 것이 좋습니다.
        //    // 예: dict.Add("ThemeIdentifier", "MySpecificTheme");
        //    //    ... Application.Current.Resources.MergedDictionaries.Remove(
        //    //        mergedDictionaries.FirstOrDefault(rd => rd.Contains("ThemeIdentifier") && (string)rd["ThemeIdentifier"] == "MySpecificTheme"));

        //    // 가장 간단하고 확실한 방법은, App.xaml에서 ThemeManager가 관리할 ResourceDictionary를
        //    // 직접 병합하지 않고, ThemeManager가 생성하는 ResourceDictionary만 관리하도록 하는 것입니다.
        //    // 즉, App.xaml의 MergedDictionaries는 비워두고, ThemeManager가 독점적으로 채우는 방식입니다.
        //    // 아니면, 테마 딕셔너리마다 고유한 메타데이터 (예: Source URI)를 부여하고 제거 로직에 활용합니다.

        //    // 일단 가장 기본적인 방법으로, 이전에 추가된 모든 동적 딕셔너리를 제거한다고 가정합니다.
        //    // 실제로는 ThemeManager가 추가한 딕셔너리만 제거해야 합니다.
        //    var dictionariesToRemove = new List<ResourceDictionary>();
        //    foreach (var dict in mergedDictionaries)
        //    {
        //        // 이 딕셔너리가 우리가 동적으로 추가한 테마 딕셔너리인지 판단하는 로직 필요
        //        // 예: 만약 딕셔너리가 특정 키 (예: "SimpleVisualTheme.IsManagedTheme")를 포함한다면 제거.
        //        if (dict.Contains("SimpleVisualTheme.ThemeKey.FontSize.Header")) // 임시 식별자 예시
        //        {
        //            dictionariesToRemove.Add(dict);
        //        }
        //    }

        //    foreach (var dict in dictionariesToRemove)
        //    {
        //        mergedDictionaries.Remove(dict);
        //    }
        //}
    }
}