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
			this.Id = parentComponent.Id + "_" + this.Id;
		} else
		{
			this.Id = this._initId;
		}
		
		if (this.Id == null || typeof this.Id == "undefined")
		{
			throw new Error('ID IS NULL');
		}
		
		this._parentComponent = parentComponent;
	}
	
	public get Parent(): CompositeComponentBase
	{
		return this._parentComponent;
	}
}