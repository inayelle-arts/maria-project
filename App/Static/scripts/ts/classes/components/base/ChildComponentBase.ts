import {CompositeComponentBase} from "./CompositeComponentBase";

export abstract class ChildComponentBase extends CompositeComponentBase
{
	private readonly _initId: string;
	
	private _parentComponent: CompositeComponentBase;
	
	protected constructor(id: string, html: HTMLElement, parent: CompositeComponentBase = null)
	{
		super(id, html);
		this._initId = id;
		this.Parent = parent;
	}
	
	public set Parent(parentComponent: CompositeComponentBase)
	{
		if (parentComponent != null)
		{
			this.Id = parentComponent.Id + "_" + this._initId;
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