サンプルプロジェクトの使い方

□動作環境
Visual Studio は最新の SP（サービスパック）あるいは Update をインストールしてください。拡張機能も全て最新のバージョンに更新してください。
お勧めは Visual Studio 2015 の無料の Community エディションを使用するか、Enterprise エディションの評価版を使用します。

※サンプルを作成・動作確認した環境は、以下の通りです。
・Visual Studio 2015 Update 5（Enterprise）
・Visual Studio 2013 Update 5（Ultimate）
・Visual Studio 2012 Update 5（Ultimate）
・Visual Studio 2010 SP1（Ultimate）

□追加のソフトウェア・拡張機能
必要に応じて、それぞれダウンロードしてインストールしてください。

■NuGet パッケージマネージャ
拡張機能マネージャから、最新のバージョンに更新してください。

■.NET Framework 4.6 ターゲットパック
・Visual Studio 2013
・Visual Studio 2012
Targeting .NET Platforms
http://getdotnet.azurewebsites.net/target-dotnet-platforms.html
Windows Vista SP2、Windows 7 SP1、Windows 8、Windows 8.1、Windows Server 2008 SP2、Windows Server 2008 R2 SP1、Windows Server 2012、Windows Server 2012 R2、および Windows 10 用 Microsoft .NET Framework 4.6 Targeting Pack および言語パック 
http://www.microsoft.com/ja-jp/download/details.aspx?id=48136

※Visual Studio 2015 には追加のインストールは必要ありません。標準で 4.6 を使用できます。
※Visual Studio 2010 では .net Framework 4.0 までしか使用できません。サンプルも 4.0 で作成しています。

■SQL Server 2014
必要に応じて、SQL Server 2014 の Management Studio および、LocalDB をインストールしてください。
サンプルの既定のDB接続先は次の通りです。

◇ MvvmSample - MVVMのサンプル
　ぞれぞれ Visual Studio をインストールした時に使用できる既定のデータベースとしてあります。必要に応じて、web.confing・app.configを変更してください。
　　Visual Studio 2015：　(localdb)\ProjectsV12 ※ SQL Server 2014 LocalDB
　　Visual Studio 2013：　(LocalDB)\V11.0 ※ SQL Server 2012 LocalDB
　　Visual Studio 2012：　(LocalDB)\V11.0 ※ SQL Server 2012 LocalDB
　　Visual Studio 2010：　.\SQLEXPRESS ※ SQL Server 2008 Express Edition の一般的なインスタンス名

◇ UnitTest - 単体テストのサンプル
　全て (localdb)\ProjectsV12 に接続します。※単体テスト実行時に自動的に接続先が決まります。SQL Server 2012 を使用したい場合は、単体テストの TODO コメントを参照してください。

SQL Server 2014 LocalDB をインストールすると、全てのプロジェクトのDB接続先を (localdb)\ProjectsV12 に変更出来ます。
Visual Studio Online でDBを使用した単体テストを実行するには、接続先を (localdb)\ProjectsV12 にする必要があります。（2015年9月21日現在）

■Visual Studio  SQL Server データベースプロジェクト
・Visual Studio 2015
・Visual Studio 2013
・Visual Studio 2012
Download Latest SQL Server Data Tools
https://msdn.microsoft.com/en-us/library/mt204009.aspx

※Visual Studio 2010 には追加のインストールは必要ありません。

■ASP.NET MVC 5
・Visual Studio 2015
・Visual Studio 2013
・Visual Studio 2012
ASP.NET および Web Tools 2013.1 for Visual Studio 2012 
http://www.microsoft.com/ja-jp/download/details.aspx?id=41532

■ASP.NET MVC 4
・Visual Studio 2010
Visual Studio 2010 SP1 および Visual Web Developer 2010 SP1 用 ASP.NET MVC 4 
http://www.microsoft.com/ja-jp/download/details.aspx?id=30683

■TypeScript
・Visual Studio 2015　※拡張機能マネージャから更新できます。
http://www.microsoft.com/ja-jp/download/details.aspx?id=48593

・Visual Studio 2013
http://www.microsoft.com/ja-jp/download/details.aspx?id=48739

※Visual Studio 2012, 2010 では TypeScript は使用できません。

※サンプルは TypeScript 1.5 を使用して作成しています。
　バージョンが変わった場合は、MVVMサンプルの TypeScriptのプロジェクトファイル（MvvmSampleJs.csproj）をテキストエディタで開いてパスを変更してください。
　C:\Program Files (x86)\Microsoft SDKs\TypeScript\1.5\tsc.exe

■Microsoft Ajax Minifier
TypeScript プロジェクトの Release ビルド時に、JavaScript と CSS を圧縮（.minファイルを作成）するために使用します。
・Visual Studio 2015
・Visual Studio 2013
http://ajaxmin.codeplex.com/
※インストール先に応じて、MVVMサンプルの TypeScriptのプロジェクトファイル（MvvmSampleJs.csproj）をテキストエディタで開いてパスを変更してください。
　C:\Program Files (x86)\Microsoft\Microsoft Ajax Minifier\AjaxMin.exe

■WPFリボン
・Visual Studio 2010
Microsoft Ribbon for WPF October 2010 
http://www.microsoft.com/en-us/download/details.aspx?id=11877 
※Visual Studio 2015, 2013, 2012 には追加のインストールは必要ありません。

■Visual Studio Installer（セットアップ）
・Visual Studio 2015
・Visual Studio 2013
拡張機能マネージャから「Visual Studio Installer」で検索してインストールしてください。
※Visual Studio 2010 には追加のインストールは必要ありません。
※Visual Studio 2012 では Visual Studio Installer は使用できません。

■Moles（Fakes の代わりの単体テスト）
・Visual Studio 2010
Visual Studio 2010 Moles x64 - Isolation Framework for .NET
https://visualstudiogallery.msdn.microsoft.com/22c07bda-ffc9-479a-9766-bfd6ccacabd4/
※詳細な使い方のテキストを単体テストのサンプルの中に用意しました。参照してください。
※Visual Studio 2015, 2013, 2012 では Fakes が使用できる上位エディションを使用します。Molesは使用できません。

