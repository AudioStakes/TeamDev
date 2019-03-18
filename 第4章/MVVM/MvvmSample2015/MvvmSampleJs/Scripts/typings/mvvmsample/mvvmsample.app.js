var mvvmsample;
(function (mvvmsample) {
    var App = (function () {
        function App() {
        }
        App.prototype.Start = function () {
            var w = new mvvmsample.Window;
            w.Render();
            w.Start();
            var homePage = new mvvmsample.HomePage(this.Settings);
            var productsPage = new mvvmsample.ProductsPage(this.Settings);
            w.Frame.Show(homePage);
            var group1 = w.Ribbon.AddNewGroup();
            var homeCommand = new mvvmsample.AppCommand("Home", "home");
            homeCommand.Action = function (sender, e) {
                w.Frame.Show(homePage);
            };
            group1.AddCommand(homeCommand);
            var productsCommand = new mvvmsample.AppCommand("Products", "products");
            productsCommand.Action = function (sender, e) {
                w.Frame.Show(productsPage);
            };
            group1.AddCommand(productsCommand);
            var group2 = w.Ribbon.AddNewGroup();
            var refreshCommand = new mvvmsample.AppCommand("Refresh", "refresh");
            refreshCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanRefresh) {
                    var page = a;
                    page.Refresh();
                }
                else {
                    alert("現在の表示では Refresh は実行出来ません");
                } // end if
            };
            group2.AddCommand(refreshCommand);
            var group3 = w.Ribbon.AddNewGroup();
            var newItemCommand = new mvvmsample.AppCommand("New Item", "newItem");
            newItemCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanAddNewItem) {
                    var page = a;
                    page.AddNewItem();
                }
                else {
                    alert("現在の表示では New Item は実行出来ません");
                } // end if
            };
            group3.AddCommand(newItemCommand);
            var editItemCommand = new mvvmsample.AppCommand("Edit Item", "editItem");
            editItemCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanEditItem) {
                    var page = a;
                    page.EditItem();
                }
                else {
                    alert("現在の表示では Edit Item は実行出来ません");
                } // end if
            };
            group3.AddCommand(editItemCommand);
            var deleteItemCommand = new mvvmsample.AppCommand("Delete Item", "deleteItem");
            deleteItemCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanDeleteItem) {
                    var page = a;
                    page.DeleteItem();
                }
                else {
                    alert("現在の表示では Delete Item は実行出来ません");
                } // end if
            };
            group3.AddCommand(deleteItemCommand);
        };
        return App;
    }());
    mvvmsample.App = App;
})(mvvmsample || (mvvmsample = {}));
//# sourceMappingURL=mvvmsample.app.js.map