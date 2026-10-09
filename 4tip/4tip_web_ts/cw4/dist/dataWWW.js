export function generInput() {
    const input = document.createElement("input");
    input.type = "number";
    input.id = "number";
    return input;
}
export const generButton = (content) => {
    const button = document.createElement("button");
    button.textContent = content;
    return button;
};
export function generList(type, count) {
    const list = document.createElement(type);
    for (let i = 0; i < count; i++) {
        const li = document.createElement("li");
        li.textContent = `element numer; ${i + 1}`;
        list.appendChild(li);
    }
    return list;
}
//# sourceMappingURL=dataWWW.js.map