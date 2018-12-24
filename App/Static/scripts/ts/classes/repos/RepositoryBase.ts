import {RepositoryManager} from "./RepositoryManager";
import {IRepository} from "./IRepository";

export abstract class RepositoryBase<TEntity> implements IRepository<TEntity>
{
	private readonly _manager : RepositoryManager;
	
	public constructor(manager: RepositoryManager)
	{
		this._manager = manager;
	}
	
	protected get Manager() : RepositoryManager
	{
		return this._manager;
	}
	
	abstract add(entity: TEntity): boolean;
	
	abstract delete(entity: TEntity): boolean;
	
	abstract get(id: number): TEntity;
	
	abstract getAll(): TEntity[];
	
	abstract update(entity: TEntity): boolean;
}