using System.Data;

/*
 * .NET에서 싱클톤 패턴으로 구현한 여러가지 클래스들이 많다.
 * 
 * - .NET Framework에서 Singleton을 구현한 public 클래스의 예로 System.Date 네임스페이스
 *   하에 있는 DataRowComparer<TRow> 클래스를 들 수 있다.
 *   
 *   이 클래스는 DataRow가 같은지, 틀린지를 비교하는 기능을 제공한다.
 */

namespace CSharpSoftwareDesignPattern.Singleton_Pattern
{
    internal class SingletonNetFramwork
    {
    }
    
    // System.Data namespace
    public sealed class DataRowComparer<TRow>
    {
        private DataRowComparer() { }

        private static DataRowComparer<TRow> _instance = new DataRowComparer<TRow>();

        /// <summary>
        /// Gets the singleton instance of the data row comparer.
        /// </summary>
        public static DataRowComparer<TRow> Default // Default : DataRowComparer<TRow>의 singleton 인스턴스를 가져옵니다. 이 속성은 읽기 전용입니다.
        {
            get { return _instance; }
        }
    }

    class Ex003_Client
    {
        public static void HowToTest()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string)); // 컬럼 생성
            DataRow row1 = table.Rows.Add("Lee");   // 생성된 Name열에 데이터 저장.
            DataRow row2 = table.Rows.Add("LEE");

            // Singleton 인스턴스 사용
            bool same = DataRowComparer.Default.Equals(row1, row2);
            Console.WriteLine(same); // false
        }
    }
}
