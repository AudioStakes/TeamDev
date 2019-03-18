How to test codes connecting database on Visual Studio, Visual Studio Online and Team Foundation Server 

	1. Install "Surviveplus.UnitTestPlus" to the unit test project from NuGet Package Manager.
	2. Create database files (.mdf, .ldf, .dacpac, .bacpac). For example, use SQL Server management studio.
	3. Add "Database" folder to the project, and add database files (.mdf, .ldf, .dacpac, .bacpac) in this folder.

	4. Change the properties of database files, like this ...

		Advanced :
			Build Action : "Content"
			Copy to Output Directory : "Copy if newer" or "Copy always"

	5. Add TestContext property to TestClass, if it don't exist.

		public TestContext TestContext { get; set; }

	6. Add code, using block of UnitTestDatabases, to TestMethod, and add code to call  AttachFiles method.

		using (var db = new UnitTestDatabases( this ) ) {
			db.AttachFiles();

	7. Get Connection String to test databases by CreateAttachedEntityConnectionString/CreateAttachedConnectionString method.

			var entityConnectionString = db.CreateAttachedEntityConnectionString( "UnitTestSampleModel", "UnitTestSample" );
			var commandConnectionString = db.CreateAttachedConnectionString("UnitTestSample");

	8. Use Microsoft Fakes as needed to apply the Connection String to test target class/method. For example,  like this example...

			using (ShimsContext.Create()) {
				System.Configuration.Fakes.ShimConnectionStringSettingsCollection.AllInstances.ItemGetString = ( me, key ) =>{
						if (key == "UnitTestSampleEntities") {
							return new ConnectionStringSettings( "UnitTestSampleEntities", entityConnectionString, "System.Data.EntityClient" );
						}else {
							return me[key];
						}
					};

	9. Run tests, on Visual Studio 2013 of local PC.

		The framework copy all database files to the folder for Unit Test, and attach (or import).
		After the test running, all databases are detached.
		When the test is passed, the folder for Unit Test is removed.
		On the other hand, when the test is failed, the folder is remained. You can confirm the database file, in this folder.

	10. Open "Builds" of Team Explorer, to create build definition to test on TFS/VSO.
