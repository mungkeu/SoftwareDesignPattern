using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CSharpSoftwareDesignPattern.Singleton_Pattern
{
    internal class Configuration
    {
        // Singleton 인스턴스 속성
        public static Configuration Setting { get; } = new Configuration();

        // Configuration 객체가 갖는 데이터
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        // private 생성자
        private Configuration()
        {
            LoadConfig();
        }

        // Config 파일 읽기
        private void LoadConfig()
        {
            var str = File.ReadAllText("Config.json");
            JObject jo = JObject.Parse(str);

            foreach(var kv in jo)
            {
                dict.Add(kv.Key, kv.Value);
            }
        }

        // Key에 대한 Value를 리턴하는 인덱서
        public object this[string key]
        {
            get { return dict[key]; }
        }
    }

    class Ex002_Client
    {
        public static void HowToTest()
        {
            // 읽어온 Config에서 아래의 Key에 해당하는Value를 받아온다.
            var user = Configuration.Setting["Username"];
            var server = Configuration.Setting["Server"];
            Console.WriteLine($"{server},{user}");
        }
    }
}
/*
 * Singleton 패턴의 좀더 실용적인 예제
 * - 환경 설정을 위해 Config.json 파일에 여러 읽기 전용 설정 값들을 지정했다고 가정하고
 * - 이러한 설정 값들을 읽어 들여 전역적으로 사용할 수 있도록 하는 Configuration 클래스를 작성
 * - 이 클래스는 프로그램 실행 중 여러번 객체를 새로 생성할 필요가 없고, 전역적으로 하나의
 * - 객체만 갖도록 작성한다.
 */