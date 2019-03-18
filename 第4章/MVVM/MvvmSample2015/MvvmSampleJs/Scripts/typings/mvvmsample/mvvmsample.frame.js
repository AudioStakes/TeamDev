var mvvmsample;
(function (mvvmsample) {
    var Window = (function () {
        function Window() {
            this.selector = "#window";
            this.ribbon = new Ribbon(this, "ribbon");
            this.frame = new Frame(this, "frame");
        }
        Object.defineProperty(Window.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        Window.prototype.Render = function () {
            $("body").children().each(function (index, elem) {
                $(elem).remove();
            });
            $("body").append("<div id=\"window\"></div>");
            this.container = $(this.selector);
            this.ribbon.Render();
            this.frame.Render();
        }; // end sub
        Window.prototype.Start = function () {
            this.container = $(this.selector);
            this.ribbon.Start();
            this.frame.Start();
        }; // end sub
        Object.defineProperty(Window.prototype, "Ribbon", {
            get: function () {
                return this.ribbon;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Window.prototype, "Frame", {
            get: function () {
                return this.frame;
            },
            enumerable: true,
            configurable: true
        });
        return Window;
    }()); // end class
    mvvmsample.Window = Window;
    var Ribbon = (function () {
        function Ribbon(parent, id) {
            this.itemIdex = 0;
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(Ribbon.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        Ribbon.prototype.Render = function () {
            this.parent.Container.append("<nav id='" + this.id + "'>" +
                "</nav>");
        }; // end sub
        Ribbon.prototype.Start = function () {
            this.container = this.parent.Container.find(this.selector);
        }; // end sub
        Ribbon.prototype.AddNewGroup = function () {
            this.itemIdex += 1;
            var id = "RibbonGroup" + this.itemIdex;
            var group = new RibbonGroup(this, id);
            group.Render();
            group.Start();
            return group;
        }; // end sub
        return Ribbon;
    }()); // end class
    mvvmsample.Ribbon = Ribbon;
    var RibbonGroup = (function () {
        function RibbonGroup(parent, id) {
            this.itemIdex = 0;
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(RibbonGroup.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        RibbonGroup.prototype.Render = function () {
            this.parent.Container.append("<ul id='" + this.id + "'>" +
                "</ul>");
        }; // end sub
        RibbonGroup.prototype.Start = function () {
            this.container = this.parent.Container.find(this.selector);
        }; // end sub
        RibbonGroup.prototype.AddCommand = function (command) {
            this.itemIdex += 1;
            var id = "AppComand" + this.itemIdex;
            var button = new RibbonButton(this, id, command);
            button.Render();
            button.Start();
        }; // end sub
        return RibbonGroup;
    }()); // end class
    mvvmsample.RibbonGroup = RibbonGroup;
    var EventArgs = (function () {
        function EventArgs() {
        }
        return EventArgs;
    }()); // end class
    EventArgs.Empty = new EventArgs();
    mvvmsample.EventArgs = EventArgs;
    var AppCommand = (function () {
        function AppCommand(text, icon) {
            this.text = text;
            this.icon = icon;
        } // end constructor
        Object.defineProperty(AppCommand.prototype, "Text", {
            get: function () {
                return this.text;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(AppCommand.prototype, "Icon", {
            get: function () {
                return this.icon;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        AppCommand.prototype.Invoke = function () {
            if (this.Action != null)
                this.Action(this, EventArgs.Empty);
        }; // end sub
        return AppCommand;
    }()); // end class
    mvvmsample.AppCommand = AppCommand;
    var RibbonButton = (function () {
        function RibbonButton(parent, id, command) {
            this.parent = parent;
            this.command = command;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(RibbonButton.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        RibbonButton.prototype.Render = function () {
            var iconClassName = "";
            if (this.command.Icon != null) {
                iconClassName = this.command.Icon + "Button ";
            }
            this.parent.Container.append("<li><a id='" + this.id + "' class='" + iconClassName + "linkButton' >" +
                this.command.Text +
                "</a></li>");
        }; // end sub
        RibbonButton.prototype.Start = function () {
            var _this = this;
            this.container = this.parent.Container.find(this.selector);
            this.container.click(function () {
                _this.command.Invoke();
            });
        }; // end sub
        return RibbonButton;
    }()); // end class
    mvvmsample.RibbonButton = RibbonButton;
    var Frame = (function () {
        function Frame(parent, id) {
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(Frame.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        Frame.prototype.Render = function () {
            this.parent.Container.append("<article id='" + this.id + "'></article>");
        }; // end sub
        Frame.prototype.Start = function () {
            this.container = this.parent.Container.find(this.selector);
            this.viewContainer = this.container;
        }; // end sub
        Object.defineProperty(Frame.prototype, "View", {
            get: function () {
                return this.view;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Frame.prototype, "ViewContainer", {
            get: function () {
                return this.viewContainer;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        Frame.prototype.Show = function (view) {
            this.viewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.view = view;
            view.Parent = this;
        }; // end sub
        return Frame;
    }()); // end class
    mvvmsample.Frame = Frame;
})(mvvmsample || (mvvmsample = {}));
//# sourceMappingURL=mvvmsample.frame.js.map