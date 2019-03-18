var mvvmsample;
(function (mvvmsample) {
    var EditProductPage = (function () {
        function EditProductPage(product, backtoPage, settings) {
            this.backtoPage = backtoPage;
            this.settings = settings;
            this.product = product;
            if (!this.product) {
                this.product = { "Id": "", "Title": "", "ProductUrl": "", "DownloadUrl": "", "Description": "", "Publisher": "", "PublisherUrl": "", "ImageUrl": "", "Price": "" };
            } // end if
        }
        Object.defineProperty(EditProductPage.prototype, "Parent", {
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
        EditProductPage.prototype.Refresh = function () {
            var _this = this;
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='editProductPage'>" +
                "<h1>Product Item</h1>" +
                "<input type='hidden' data-bind='value:Id' />" +
                "<p>Title : <input type='text' data-bind='value:Title' /></p>" +
                "<p>ProductUrl : <input type='text' data-bind='value:ProductUrl' /></p>" +
                "<p>DownloadUrl : <input type='text' data-bind='value:DownloadUrl' /></p>" +
                "<p>Description : <input type='text' data-bind='value:Description' /></p>" +
                "<p>Publisher : <input type='text' data-bind='value:Publisher' /></p>" +
                "<p>PublisherUrl : <input type='text' data-bind='value:PublisherUrl' /></p>" +
                "<p>Price : <input type='text' data-bind='value:Price' /></p>" +
                "<p><input class='saveButton' type='button' value='Save' /></p>" +
                "<div>");
            var s = {
                type: this.settings.PostOrGetForSaveProduct,
                url: this.settings.UriForSaveProduct,
                dataType: "json",
                timeout: 10000,
                success: function (result) {
                    if (result.success) {
                        var frame = _this.Parent;
                        if (frame.Show)
                            frame.Show(_this.backtoPage);
                        var page = _this.backtoPage;
                        if (page.CanRefresh)
                            page.Refresh();
                    }
                    else {
                        alert("error");
                    } // end if
                },
                error: function (result) {
                    alert("error");
                }
            };
            this.parent.ViewContainer.find(".saveButton").click(function () {
                s.data = _this.product;
                $.ajax(s);
            });
            ko.applyBindings(this.product, this.parent.ViewContainer.find(".editProductPage")[0]);
        }; // end sub
        return EditProductPage;
    }()); // end class
    mvvmsample.EditProductPage = EditProductPage;
})(mvvmsample || (mvvmsample = {}));
//# sourceMappingURL=mvvmsample.editproduct.js.map