namespace CSharpSoftwareDesignPattern.Singleton_Pattern
{
    internal sealed class SingletonPattern
    {
        // private 생성자를 호출해서 하나의 인스턴스를 생성
        // readonly 이므로 외부에서 필드를 다른 값으로 설정 불가.
        public static readonly SingletonPattern Instance = new SingletonPattern();

        // 다른 외부 클래스가 사용할 수 없도록 private으로 설정
        private SingletonPattern()
        {

        }
        public void Method()
        {
            Console.WriteLine("싱클톤 패턴");
        }
    }
    
    class Ex001_Client
    {
        public static void HowToTest()
        {
            SingletonPattern.Instance.Method();
        }
    }
}
/*
 * Singleton 패턴
 * - 카테고리 : 생성 패턴 (Creational Pattern)
 * - 개요 : 하나의 클래스가 단지 하나의 인스턴스만 갖도록 제한하고, 전역 범위에서 그 인스턴스를
 *          엑세스할 수 있게 하는 패턴이다.
 *          이 패턴은 시스템 전체에 걸쳐 하나의 인스턴스가 모든 처리를 조율해야 하는 곳에 유용하다.
 * 
 * Singleton Design Pattern은 클래스가 하나의 인스턴스만을 갖도록 하고, 그 인스턴스를 시스템 전역
 * 에서 엑세스할 수 있도록 하는 패턴이다.
 */