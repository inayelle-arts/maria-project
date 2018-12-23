export abstract class ComponentBase
{
	protected readonly dom: JQuery<HTMLElement>;
	
	protected constructor(dom: JQuery<HTMLElement>)
	{
		this.dom = dom;
	}
	
	protected childFirstOrDefault(className: string): JQuery<HTMLElement>
	{
		return this.dom.find(`.${className}:first`);
	}
	
	protected children(className: string): Array<JQuery<HTMLElement>>
	{
		return [].slice.apply(this.dom.children(`.${className}`));
	}
	
	protected childrenFrom(className: string, source: JQuery<HTMLElement>)
	{
		return [].slice.apply(source.children(`.${className}`));
	}
	
	protected get html(): string
	{
		return this.dom.html();
	}
	
	public get jDom() : JQuery<HTMLElement>
	{
		return this.dom;
	}
}