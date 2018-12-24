import {LayoutRepository} from "../../repos/LayoutRepository";
import {CompositeComponentBase} from "./CompositeComponentBase";

export abstract class ChildComponentBase extends CompositeComponentBase
{
	protected static readonly LayoutStorage: LayoutRepository = new LayoutRepository();
	
	private readonly _layout: string;
	private readonly _initId: string;
	
	private _parentComponent: CompositeComponentBase;
	
	protected constructor(id: string, layout: string)
	{
		const tag = $(layout).prop('tagName');
		const html = document.createElement(tag);
		html.id = id;
		html.innerHTML = $(layout).prop('innerHTML');
		
		super(id, html);
		this._initId = id;
		this._layout = layout;
		this._parentComponent = null;
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
		
		this.Dom.id = this.Id;
		
		this._parentComponent = parentComponent;
	}
	
	public get Parent(): CompositeComponentBase
	{
		return this._parentComponent;
	}
}