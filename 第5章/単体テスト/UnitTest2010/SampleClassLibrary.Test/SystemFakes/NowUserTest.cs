using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using SampleClassLibrary.SystemFakes;
using Net.Surviveplus.UnitTestPlus;

namespace SampleUnitTest.SystemFakes
{
    [TestClass]
    public class NowUserTest
    {
        [HostType("Moles")]
        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Execute_正常系_引数がaで現在の日付が2015年1月2日の時にTrueを返すこと()
        {

            var target = new NowUser();

            // Moles を使用します（README.txt 参照）

            // 環境 
            var environment = new
            {
                Now = new DateTime(2015, 1, 2)
            };
            ReportingConsole.WriteFakes(environment);
            System.Moles.MDateTime.NowGet = () =>
            {
                ReportingConsole.WriteFakesCalled("System.DateTime.Now");
                return environment.Now;
            };

            // メソッド引数・結果期待値（戻り値・プロパティ）
            var args = new
            {
                userName = "a",
            };
            var expected = new
            {
                returnValue = true,
                Now = new DateTime(2015, 1, 2),
            };
            ReportingConsole.WriteArgsAndExpected(args, expected);

            // 実行と結果
            var actual = new
            {
                returnValue = target.Execute(args.userName),
                Now = target.Now,
            };
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<bool>(expected.returnValue, actual.returnValue);
            Assert.AreEqual<DateTime>(expected.Now, actual.Now);
        } // end function

        [HostType("Moles")]
        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Execute_異常系_引数がaで現在の日付が2014年12月31日の時にFalseを返すこと()
        {

            var target = new NowUser();

            // Moles を使用します（README.txt 参照）

            // 環境 
            var environment = new
            {
                Now = new DateTime(2014, 12, 31)
            };
            ReportingConsole.WriteFakes(environment);
            System.Moles.MDateTime.NowGet = () =>
            {
                ReportingConsole.WriteFakesCalled("System.DateTime.Now");
                return environment.Now;
            };

            // メソッド引数・結果期待値（戻り値・プロパティ）
            var args = new
            {
                userName = "a",
            };
            var expected = new
            {
                returnValue = false,
                Now = new DateTime(2014, 12, 31),
            };
            ReportingConsole.WriteArgsAndExpected(args, expected);

            // 実行と結果
            var actual = new
            {
                returnValue = target.Execute(args.userName),
                Now = target.Now,
            };
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<bool>(expected.returnValue, actual.returnValue);
            Assert.AreEqual<DateTime>(expected.Now, actual.Now);

        } // end function


    } // end class
} // end namespace
