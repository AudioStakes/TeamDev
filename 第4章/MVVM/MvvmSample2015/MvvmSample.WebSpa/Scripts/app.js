$().ready(function () {
    var settings = {
        UriForHome: "/api/Home/",
        UriForProducts: "/api/Products/",
        UriForSaveProduct: "/api/SaveProduct",
        PostOrGetForSaveProduct: "post"
    };
    var app = new mvvmsample.App;
    app.Settings = settings;
    app.Start();
});
//# sourceMappingURL=app.js.map