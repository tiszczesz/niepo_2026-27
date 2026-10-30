export const H1 = (content: string, style: string = ""): HTMLHeadingElement => {
  const h1 = document.createElement("h1");
  h1.style = style;
  h1.textContent = content;
  return h1;
};
