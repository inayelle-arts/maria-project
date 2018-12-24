import {CompositeComponentBase, JAttribute, JProperty} from "./CompositeComponentBase";
import {LayoutRepository} from "../../repos/LayoutRepository";
import {JFactory} from "../JFactory";

export abstract class ChildComponentBase extends CompositeComponentBase
{
	protected static readonly LayoutStorage: LayoutRepository = new LayoutRepository();
	
	private readonly _layout: string;
	private readonly _initId: string;
	
	private _parentComponent: CompositeComponentBase;
	
	private _html: string;
	
	protected constructor(id: string, layout: string)
	{
		super(id);
		this._initId = id;
		this._layout = layout;
		this._parentComponent = null;
		this._html = $(layout).attr('id', id).prop(JProperty.OuterHtml);
		console.log('CTOR: ~' + this._html + '~');
	}
	
	public set Parent(parentComponent: CompositeComponentBase)
	{
		if (parentComponent != null)
		{
			this.Id = parentComponent.Id + "_" + this.Id;
		} else
		{
			this.Id = this._initId;
		}
		
		this._html = $(this._html).attr('id', this.Id).prop(JProperty.OuterHtml);
		this._parentComponent = parentComponent;
	}
	
	public get Parent(): CompositeComponentBase
	{
		return this._parentComponent;
	}
	
	public renderTo(component: CompositeComponentBase): void
	{
		this.Parent = component;
		console.log('RENDERING ' + this.Id + ' to ' + component.Id);
		component.InnerHtml += this._html;
	}
	
	public unrender(): void
	{
		this._html = JFactory.getById(this.Id).prop(JProperty.OuterHtml);
		JFactory.removeById(this.Id);
		this.Parent = null;
	}
}