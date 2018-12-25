import {RepositoryManager} from "./RepositoryManager";
import {IRepository} from "./IRepository";
import {JsonConvert} from "json2typescript";

export abstract class RepositoryBase<TEntity> implements IRepository<TEntity>
{
	private readonly _manager : RepositoryManager;
	private readonly _converter = new JsonConvert();
	
	public constructor(manager: RepositoryManager)
	{
		this._manager = manager;
	}
	
	protected get Manager() : RepositoryManager
	{
		return this._manager;
	}
	
	protected get JsonConverter() : JsonConvert
	{
		return this._converter;
	}
	
	abstract add(entity: TEntity): boolean;
	
	abstract delete(entity: TEntity): boolean;
	
	abstract get(id: number): TEntity;
	
	abstract getAll(): TEntity[];
	
	abstract update(entity: TEntity): boolean;
}