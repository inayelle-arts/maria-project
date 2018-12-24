import {ChildComponentBase} from "./ChildComponentBase";
import {JFactory} from "../JFactory";

export class CompositeComponentBase
{
	private readonly _children: Array<ChildComponentBase>;
	
	private _id: string;
	
	constructor(id: string)
	{
		this._id = id;
		this._children = new Array<ChildComponentBase>();
	}
	
	public get Id(): string
	{
		return this._id;
	}
	
	public set Id(id: string)
	{
		this.JDom.attr(JAttribute.Id, id);
		this._id = id;
		
		this._children.forEach((component: ChildComponentBase) =>
		{
			component.Id = component.Id + "_" + this.Id;
		});
	}
	
	public get JDom(): JQuery<HTMLElement>
	{
		return JFactory.getById(this._id);
	}
	
	public get Html(): string
	{
		return this.JDom.prop(JProperty.OuterHtml);
	}
	
	public get InnerHtml(): string
	{
		return this.JDom.prop(JProperty.InnerHtml);
	}
	
	public set InnerHtml(html: string)
	{
		this.JDom.prop(JProperty.InnerHtml, html);
	}
	
	public addChild(component: ChildComponentBase): void
	{
		this._children.push(component);
	
		component.renderTo(this);
	}
	
	public removeChild(component: ChildComponentBase): void
	{
		const index = this._children.indexOf(component);
		delete this._children[index];
		
		component.unrender();
	}
}

export enum JProperty
{
	InnerHtml = "innerHTML",
	OuterHtml = "outerHTML"
}

export enum JAttribute
{
	Id = "id"
}