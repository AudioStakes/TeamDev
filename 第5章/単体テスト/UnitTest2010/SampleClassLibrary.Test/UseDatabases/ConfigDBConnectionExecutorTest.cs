using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Surviveplus.UnitTestPlus;
using SampleClassLibrary.UseDatabases;


namespace SampleUnitTest.UseDatabases
{
    /// <summary>
    /// ConfigDBConnectionExecutor のテスト クラスです。すべての ConfigDBConnectionExecutor 単体テストテストをここに含めます。
    /// </summary>
    /// <remarks>Team Foundation Server, Visual Studio Online の自動ビルド・自動テストに登録するため、クラス名は必ず Test で終わる必要があります。</remarks>
    [TestClass]
    public class ConfigDBConnectionExecutorTest
    {

        /// <summary>
        /// 現在のテストの実行についての情報および機能を提供するテスト コンテキストを取得または設定します。
        /// </summary>
        public TestContext TestContext { get; set; }

        #region 追加のテスト属性

        /// <summary>
        ///  テストを作成するときに、次の追加属性を使用することができます:
        ///  クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            ReportingConsole.Culture = new System.Globalization.CultureInfo("ja-JP");
        } // end function

        /// <summary>
        /// クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        /// </summary>
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
        } // end function

        /// <summary>
        /// 各テストを実行する前にコードを実行するには、TestInitialize を使用
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // テスト実行 前 毎に TestContext の内容をコンソールに出力するには、下記のコメントアウトを解除します。
            //ReportingConsole.WriteTestContext( this.TestContext );
        } // end function

        /// <summary>
        /// 各テストを実行した後にコードを実行するには、TestCleanup を使用
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {

            // テスト実行 後 毎に TestContext の内容をコンソールに出力するには、下記のコメントアウトを解除します。
            //ReportingConsole.WriteTestContext( this.TestContext );
        } // end function

        #endregion

        [HostType("Moles")]
        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Execute_正常系_初期データに登録されていないテキストをアップデート出来ること()
        {

            // テスト用DBファイルを使用します。
            using (var db = new UnitTestDatabases(this) )
            {
                db.AttachFiles();

                // 環境
                var environment = new
                {
                    ConnectionStrings = new
                    {
                        UnitTestSampleModelContainer = db.CreateAttachedEntityConnectionString("UnitTestSampleModel", "UnitTestSample")
                    }
                };
                ReportingConsole.WriteFakes(environment);

                // 下記の設定は出来ないので（読み取り専用）、代わりに Moles で置き換えます。（README.txt 参照）
                //	ConfigurationManager.ConnectionStrings["UnitTestSampleEntities"].ConnectionString = environment.ConnectionStrings.UnitTestSampleEntities;
                //
                var c = new ConnectionStringSettings("UnitTestSampleModelContainer", environment.ConnectionStrings.UnitTestSampleModelContainer, "System.Data.EntityClient");
                System.Configuration.Moles.MConnectionStringSettingsCollection.AllInstances.ItemGetString = (me, key) =>
                {
                    ReportingConsole.WriteFakesCalled("System.Configuration.ConfigurationManager.ConnectionStrings インデクサ（デフォルトプロパティ）");
                    if (key == "UnitTestSampleModelContainer")
                    {
                        return c;
                    }
                    else
                    {
                        return me[key];
                    }
                };

                var target = new ConfigDBConnectionExecutor();

                // メソッド引数
                var args = "Sample";
                ReportingConsole.WriteArgsWithNoExpected(args, NoExpectedReason.Void);

                // 実行と確認
                target.Execute(args);


            }// end using(db)
        } // end function

        [HostType("Moles")]
        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Count_正常系_初期データ3件登録されていてExecuteでデータを1件登録した後にCountで4が取得出来ること()
        {

            // テスト用DBファイルを使用します。
            using (var db = new UnitTestDatabases(this))
            {
                //db.Server = TestDatabaseKind.SqlServer2012ExpressLocalDB;
                db.AttachFiles();

                // 環境
                var environment = new
                {
                    ConnectionStrings = new
                    {
                        UnitTestSampleModelContainer = db.CreateAttachedEntityConnectionString("UnitTestSampleModel", "UnitTestSample"),
                        UnitTestSample = db.CreateAttachedConnectionString("UnitTestSample")

                    }
                };
                ReportingConsole.WriteFakes(environment);

                // 下記の設定は出来ないので（読み取り専用）、代わりに Moles で置き換えます。（README.txt 参照）
                //	ConfigurationManager.ConnectionStrings["UnitTestSampleEntities"].ConnectionString = environment.ConnectionStrings.UnitTestSampleEntities;
                //	ConfigurationManager.ConnectionStrings["UnitTestSample"].ConnectionString = environment.ConnectionStrings.UnitTestSample;
                //
                var c = new ConnectionStringSettings("UnitTestSampleModelContainer", environment.ConnectionStrings.UnitTestSampleModelContainer, "System.Data.EntityClient");
                var c2 = new ConnectionStringSettings("UnitTestSample", environment.ConnectionStrings.UnitTestSample, "System.Data.Client");
                System.Configuration.Moles.MConnectionStringSettingsCollection.AllInstances.ItemGetString = (me, key) =>
                {
                    ReportingConsole.WriteFakesCalled("System.Configuration.ConfigurationManager.ConnectionStrings インデクサ（デフォルトプロパティ）");
                    if (key == "UnitTestSampleModelContainer")
                    {
                        return c;
                    }
                    else if (key == "UnitTestSample")
                    {
                        return c2;
                    }
                    else
                    {
                        return me[key];
                    }
                };

                var target = new ConfigDBConnectionExecutor();

                // メソッド引数
                var args = "Sample";
                var expected = new
                {
                    Count = 4
                };
                ReportingConsole.WriteArgsAndExpected(args, expected);

                // 実行と確認
                target.Execute(args);
                var actual = target.Count();

                Assert.AreEqual(expected.Count, actual);

            }// end using(db)
        } // end function

    } // end class
} // end namespace
