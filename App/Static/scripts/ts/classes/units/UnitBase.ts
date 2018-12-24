import {ComponentBase} from "../components/ComponentBase";

export abstract class UnitBase<TEntity, TComponent extends ComponentBase>
{
	private readonly _entity: TEntity;
	private readonly _component: TComponent;
	
	public constructor(entity: TEntity, component: TComponent)
	{
		this._entity = entity;
		this._component = component;
	}
	
	public get Entity(): TEntity
	{
		return this._entity;
	}
	
	public get Component(): TComponent
	{
		return this._component;
	}
}