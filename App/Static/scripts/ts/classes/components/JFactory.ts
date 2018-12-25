export class JFactory
{
	private constructor()
	{
	}
	
	public static getById(id: string): JQuery<HTMLElement>
	{
		return $(`#${id}`);
	}
	
	public static getByClass(className: string, parentId: string): JQuery<HTMLElement>
	{
		return this.getById(parentId).children('.' + className);
	}
	
	public static removeById(id: string): void
	{
		id = `#${id}`;
		$(id).remove();
	}
}