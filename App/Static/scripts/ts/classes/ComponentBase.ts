export abstract class ComponentBase
{
	protected dom: JQuery<HTMLElement>;
	
	protected constructor(dom: JQuery<HTMLElement>)
	{
		this.dom = dom;
	}
	
	protected single(selector: string): JQuery<HTMLElement>
	{
		return this.dom.children(`${selector}:first`);
	}
	
	protected where(selector: string): Array<JQuery<HTMLElement>>
	{
		return [].slice.apply(this.dom.children(selector));
	}
	
	protected remove(selector: string): void
	{
		this.dom.remove(selector);
	}
	
	protected get html(): string
	{
		return this.dom.html().trim();
	}
	
	protected set html(value: string)
	{
		this.dom.html(value);
	}
	
	protected appendHtml(html: string): void
	{
		this.dom.append(html);
	}
	
	protected prependHtml(html: string): void
	{
		this.dom.prepend(html);
	}
	
	protected appendComponent(component: ComponentBase): void
	{
		this.appendHtml(component.html);
	}
	
	protected prependComponent(component: ComponentBase): void
	{
		this.prependHtml(component.html);
	}
}