"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const commonJsFunctions = require("./cw_file1");
console.log("Hello from TS");
console.log("dsf sdf sdf");
const colors = ["red", "green", "blue"];
colors.push("yellow");
console.log(colors);
for (const color of colors) {
    console.log(`kolory: ${color}`);
}
console.log(`2 + 6 = ${commonJsFunctions.Add(2, 6)}`);
commonJsFunctions.Show();
//# sourceMappingURL=index.js.map