var mvvmsample;
(function (mvvmsample) {
    var ProductPage = (function () {
        function ProductPage(product) {
            this.product = product;
        }
        Object.defineProperty(ProductPage.prototype, "Parent", {
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
        ProductPage.prototype.Refresh = function () {
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='productPage'>" +
                "<h1>Product Item</h1>" +
                "<p>Title : <span data-bind='text:Title' /></p>" +
                "<p>Description : <span data-bind='text:Description' /></p>" +
                "<p>Publisher : <span data-bind='text:Publisher' /></p>" +
                "<p>Price : <span data-bind='text:Price' /></p>" +
                "<p>" +
                "<a target=\"_blank\" data-bind='attr: {href:DownloadUrl}'\">Download</a> " +
                "<a target=\"_blank\" data-bind='attr: {href:ProductUrl}'\">Open Site</a> " +
                "<a target=\"_blank\" data-bind='attr: {href:PublisherUrl}'\">Publisher</a> " +
                "</p>" +
                "<div>");
            ko.applyBindings(this.product, this.parent.ViewContainer.find(".productPage")[0]);
        }; // end sub
        return ProductPage;
    }()); // end class
    mvvmsample.ProductPage = ProductPage;
})(mvvmsample || (mvvmsample = {}));
//# sourceMappingURL=mvvmsample.product.js.map