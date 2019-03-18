var mvvmsample;
(function (mvvmsample) {
    var ProductsPage = (function () {
        function ProductsPage(settings) {
            // #endregion
            // #region IPageUsingRibbon members
            this.CanRefresh = true;
            this.CanAddNewItem = true;
            this.CanEditItem = false;
            this.CanDeleteItem = false;
            this.settings = settings;
        } // constructor
        Object.defineProperty(ProductsPage.prototype, "Parent", {
            get: function () {
                return this.parent;
            },
            set: function (value) {
                this.parent = value;
                this.RefreshView();
            },
            enumerable: true,
            configurable: true
        });
        ProductsPage.prototype.Refresh = function () {
            this.data = null;
            this.RefreshView();
        }; // end sub
        ProductsPage.prototype.AddNewItem = function () {
            var frame = this.Parent;
            if (frame.Show)
                frame.Show(new mvvmsample.EditProductPage(null, this, this.settings));
        }; // end sub
        ProductsPage.prototype.EditItem = function () { };
        ProductsPage.prototype.DeleteItem = function () { };
        ProductsPage.prototype.RefreshView = function () {
            var _this = this;
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='productsPage'>" +
                "<h1>Products</h1>" +
                "<table>" +
                "<thead>" +
                "<tr>" +
                "<th>Title</th>" +
                "<th>Description</th>" +
                "<th>Publisher</th>" +
                "<th>Price</th>" +
                "</tr>" +
                "</thead>" +
                "<tfoot></tfoot>" +
                "<tbody data-bind='foreach: lines'>" +
                "<tr data-bind='click: Clicked'>" +
                "<td class='nowrap' data-bind='text:Title'></td>" +
                "<td data-bind='text:Description'></td>" +
                "<td class='nowrap' data-bind='text:Publisher'></td>" +
                "<td class='nowrap' data-bind='text:Price'></td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<div>");
            if (this.data) {
                ko.applyBindings({ lines: this.data }, this.parent.ViewContainer.find(".productsPage")[0]);
            }
            else {
                var uri = this.settings.UriForProducts + "date=" + new Date().getTime();
                $.getJSON(uri).done(function (data) {
                    data.forEach(function (key, index, products) {
                        products[index].Clicked = function () {
                            //alert(index);
                            //alert(products[index].Title);
                            var product = products[index];
                            var frame = _this.Parent;
                            if (frame.Show)
                                frame.Show(new mvvmsample.ProductPage(product));
                        };
                    });
                    _this.data = data;
                    ko.applyBindings({ lines: data }, _this.parent.ViewContainer.find(".productsPage")[0]);
                });
            } // end if
        }; // end sub
        return ProductsPage;
    }()); // end class
    mvvmsample.ProductsPage = ProductsPage;
})(mvvmsample || (mvvmsample = {}));
//# sourceMappingURL=mvvmsample.products.js.map