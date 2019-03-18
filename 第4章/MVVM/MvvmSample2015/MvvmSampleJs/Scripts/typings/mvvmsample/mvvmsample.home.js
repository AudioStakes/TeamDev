var mvvmsample;
(function (mvvmsample) {
    var HomePage = (function () {
        function HomePage(settings) {
            this.settings = settings;
        } // constructor
        Object.defineProperty(HomePage.prototype, "Parent", {
            get: function () {
                return this.parent;
            },
            set: function (value) {
                this.parent = value;
                this.Refresh();
            },
            enumerable: true,
            configurable: true
        });
        HomePage.prototype.Refresh = function () {
            var _this = this;
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='homePage'>" +
                "<h1>Home</h1>" +
                "<p data-bind='text:Description'></p>" +
                "<p data-bind='text:Version'></p>" +
                "</div>");
            var uri = this.settings.UriForHome + "date=" + new Date().getTime();
            $.getJSON(uri).done(function (data) {
                ko.applyBindings(data, _this.parent.ViewContainer.find(".homePage")[0]);
            });
        }; // end sub
        return HomePage;
    }()); // end class
    mvvmsample.HomePage = HomePage;
})(mvvmsample || (mvvmsample = {}));
//# sourceMappingURL=mvvmsample.home.js.map