export class JFactory
{
	private constructor()
	{
	}
	
	public static singleById(id: string, from: JQuery<HTMLElement> = null): JQuery<HTMLElement>
	{
		return this.singleBySelector(`#${id}`);
	}
	
	public static singleByClass(className: string, from: JQuery<HTMLElement> = null): JQuery<HTMLElement>
	{
		return this.singleBySelector(`.${className}`, from);
	}
	
	public static allByClass(className: string): JQuery<HTMLElement>[]
	{
		return [].splice.apply($('.' + className));
	}
	
	public static singleBySelector(selector: string, from: JQuery<HTMLElement> = null): JQuery<HTMLElement>
	{
		const query = `${selector}:first`;
		
		if (from == null)
		{
			return $(query);
		}
		
		return from.children(query);
	}
	
	public static allBySelector(selector: string, from: JQuery<HTMLElement> = null): JQuery<HTMLElement>[]
	{
		const query = `${selector}:first`;
		
		if (from == null)
		{
			return [].splice.apply($(query));
		}
		
		return [].splice.apply(from.children(query));
	}
}