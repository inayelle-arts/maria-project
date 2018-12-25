import {ChildComponentBase} from "../components/base/ChildComponentBase";
import {RepositoryManager} from "../repos/RepositoryManager";

export abstract class UnitBase<TEntity, TComponent extends ChildComponentBase>
{
	private readonly _entity: TEntity;
	private readonly _component: TComponent;
	
	constructor(entity: TEntity, component: TComponent)
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
	
	protected get Repository() : RepositoryManager
	{
		return RepositoryManager.getInstance();
	}
}