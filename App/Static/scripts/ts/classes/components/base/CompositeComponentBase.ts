import {ChildComponentBase} from "./ChildComponentBase";
import {JFactory} from "../JFactory";

export class CompositeComponentBase
{
	private readonly _html: HTMLElement;
	
	private readonly _children: Array<ChildComponentBase>;
	
	private _id: string = null;
	
	protected constructor(id: string, html: HTMLElement = null)
	{
		if (id == null || typeof id == "undefined")
		{
			throw new Error('ID IS NULL');
		}
		
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
		if (typeof this._id == "undefined")
		{
			console.log('GET ID NULLL');
		}
		return this._id;
	}
	
	public set Id(id: string)
	{
		if (id == null || typeof id == "undefined")
		{
			throw new Error('ID IS NULL');
		}
		
		this._id = id;
		this._html.setAttribute('id', id);
		
		this._children.forEach((component: ChildComponentBase) =>
		{
			component.Id = this.Id + '_' + component.Id;
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
	
	public appendWithHtml(html: string): void
	{
		this._html.append(html);
	}
	
	public appendWithElement(element: HTMLElement): void
	{
		this._html.append(element);
	}
	
	public addChild(component: ChildComponentBase): void
	{
		this._children.push(component);
		
		component.Parent = this;
		
		this.appendWithElement(component.Dom);
	}
	
	public removeChild(component: ChildComponentBase): void
	{
		const index = this._children.indexOf(component);
		delete this._children[index];
		
		component.Parent = null;
		
		JFactory.removeById(component.Id);
	}
	
	public async show(): Promise<void>
	{
		return new Promise(() =>
		{
			this.JDom.show();
		});
	}
	
	public async hide(): Promise<void>
	{
		return new Promise(() =>
		{
			this.JDom.hide();
		});
	}
	
	public jFind(selector: string): JQuery<HTMLElement>
	{
		return this.JDom.find(selector);
	}
	
	public jFindByClass(className: string): JQuery<HTMLElement>
	{
		return this.JDom.find(`.${className}`);
	}
	
	public jFindAllByClass(className: string): JQuery<HTMLElement>[]
	{
		const result = new Array<JQuery<HTMLElement>>();
		
		$(`.${className}`).toArray().forEach((element) =>
		{
			result.push($(element));
		});
		
		return result;
	}
}