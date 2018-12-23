import {ComponentBase} from "./ComponentBase";

export class Task extends ComponentBase
{
	private static readonly TitleClass = 'task-card-title';
	private static readonly CodeClass = 'task-card-code';
	private static readonly DescriptionClass = 'task-card-description';
	
	private readonly _titleDom: JQuery<HTMLElement>;
	private readonly _codeDom: JQuery<HTMLElement>;
	private readonly _descriptionDom: JQuery<HTMLElement>;
	
	private _title: string;
	private _code: string;
	private _description: string;
	
	public constructor(dom: JQuery<HTMLElement>)
	{
		super(dom);
		
		this._titleDom = this.childFirstOrDefault(Task.TitleClass);
		this._codeDom = this.childFirstOrDefault(Task.CodeClass);
		this._descriptionDom = this.childFirstOrDefault(Task.DescriptionClass);
		
		this._title = this._titleDom.text().trim();
		this._code = this._codeDom.text().trim();
		this._description = this._descriptionDom.text().trim();
	}
	
	public get title()
	{
		return this._title;
	}
	
	public set title(value: string)
	{
		this._title = value;
		this._titleDom.text(value);
	}
	
	public get code()
	{
		return this._code;
	}
	
	public set code(value: string)
	{
		this._code = value;
		this._codeDom.text(value);
	}
	
	public get description()
	{
		return this._description;
	}
	
	public set description(value: string)
	{
		this._description = value;
		this._descriptionDom.text(value);
	}
}