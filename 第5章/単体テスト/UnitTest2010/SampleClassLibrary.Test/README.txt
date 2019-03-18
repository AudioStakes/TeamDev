■Visual Studio 2010 SP1 ＋ Moles の使い方

Visual Studio 2012 以降では Fakes を使用して、System.DateTime.Now の値を変更するテストができます。
Fakes については他のバージョンのサンプルを確認してください。

Visual Studio 2010 では Moles というツールをダウンロードしてインストールすることで、同様のテストを行う事ができます。
Fakes とほとんど同じ使い方ができますが、既定の使い方では Visual Studio 2010 SP1 以降は多数のビルドエラーが発生し、使うことができません。
ここでは、Visual Studio 2010 SP1 で Moles を使って System.DateTime.Now の値を変更するテストを行うための手順を紹介します。

1. Moles をダウンロードし、インストールしてください。
　Visual Studio 2010 Moles x64 - Isolation Framework for .NET
　https://visualstudiogallery.msdn.microsoft.com/22c07bda-ffc9-479a-9766-bfd6ccacabd4/

2. テストプロジェクトを作成します。

3. テストプロジェクトに mscorlib.moles ファイルを追加し、ビルドアクションを［Moles］とします。
　（DateTime.Now 以外を置きかえる場合は、［参照設定］のアセンブリを右クリックして［Add Moles Assembly］を選択します）

4. 作成した .moles ファイルに、<StubGeneration><Types><Clear /> と <MoleGeneration><Types><Clear /> を追加します。
　（これを指定しない場合はビルド時にエラーになってしまいます。エラーを回避するため一度全て対象外にします。）

5. テストで置きかえたいクラスを <Clear /> の後に <Add TypeName="DateTime!" /> を追加します。
　インテリセンスヘルプに表示されるように、名前の後に ! を付けないと、前方一致になってしまいますので注意が必要です。

6. ここで一度ビルドします。
　ここでエラーが出る場合には、置きかえたいクラスが SP1 からビルドできなくなってしまった可能性があります。
　SP1ではない Visual Studio 2010 を使用するか、2012 以降の Fakes の使用を検討してください。

7. AssemblyInfo.cs に　[assembly: Microsoft.Moles.Framework.MoledType(typeof(System.DateTime))]　を追加します。

8. テストメソッドの [TestMethod] 属性の前（あるいは後ろ）に、[HostType("Moles")] 属性を指定します。
　これによってこのテストメソッドで、Moles による置きかえが使用できるようになります。

9. System.Moles.MDateTime.NowGet = ラムダ式　の形でSystem.DateTime.Now を置きかえます。
　記述の方法は Fakes とほぼ同様です。名前空間が Moles が付くこと、クラス名に M が付くことに注意してください。
　以降は、ラムダ式で置きかえた実装が呼び出されます。


※ Moles を使用せずにサンプルをビルドするには、以上の手順に該当するファイルと記述を全て削除してください。
 （SystemFakes.NowUserTest.cs と UseDatabaes.ConfigDBConnectionExecutorTest.cs が Moles を使用したテストです）

