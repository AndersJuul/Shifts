"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var AboutComponent = (function () {
    function AboutComponent() {
    }
    AboutComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'my-about',
            template: "\n        <h2>About Sriracha</h2>\n\n        <p>This is what Wikipedia says about <a href=\"https://en.wikipedia.org/wiki/Sriracha_sauce_%28Huy_Fong_Foods%29\">Sriracha sauce</a>:</p>\n\n        <blockquote>It can be recognized by its bright red color and its packaging: a clear plastic bottle with a green cap, text in Vietnamese, English, Chinese, French, and Spanish, and the rooster logo. David Tran was born in 1945, the Year of the Rooster...<blockquote>\n    ",
        }), 
        __metadata('design:paramtypes', [])
    ], AboutComponent);
    return AboutComponent;
}());
exports.AboutComponent = AboutComponent;
//# sourceMappingURL=about.component.js.map