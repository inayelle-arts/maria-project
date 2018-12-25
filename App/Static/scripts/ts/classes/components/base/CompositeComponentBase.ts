import {ChildComponentBase} from "./ChildComponentBase";
import {JFactory} from "../JFactory";

export class CompositeComponentBase
{
	private readonly _html: HTMLElement;
	
	private readonly _children: Array<ChildComponentBase>;
	
	private _id: string;
	
	protected constructor(id: string, html: HTMLElement = null)
	{
		this._id = id;
		
		if (html == null)
		{
			this._html = document.getElementById(id);
		} else
		{
			this._html = html;
		}
		
		this._children = new Array<ChildComponentBase>();
	}
	
	public get Id(): string
	{
		return this._id;
	}
	
	public set Id(id: string)
	{
		this._id = id;
		this._html.id = id;
		
		this._children.forEach((component: ChildComponentBase) =>
		{
			component.Id = component.Id + "_" + this.Id;
		});
	}
	
	public get Dom(): HTMLElement
	{
		return this._html;
	}
	
	public get JDom(): JQuery<HTMLElement>
	{
		return $(this._html);
	}
	
	public get Html(): string
	{
		return this._html.outerHTML;
	}
	
	public get InnerHtml(): string
	{
		return this._html.innerHTML;
	}
	
	public set InnerHtml(html: string)
	{
		this._html.innerHTML = html;
	}
	
	public addChild(component: ChildComponentBase): void
	{
		this._children.push(component);
		
		component.Parent = this;
		
		this._html.append(component.Dom);
	}
	
	public removeChild(component: ChildComponentBase): void
	{
		const index = this._children.indexOf(component);
		delete this._children[index];
		
		component.Parent = null;
		
		JFactory.removeById(component.Id);
	}
}