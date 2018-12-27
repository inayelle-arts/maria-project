import {ResponseResultSet} from "./ResponseResultSet";

export interface IRepository<TEntity>
{
	addAsync(entity: TEntity): Promise<ResponseResultSet>;
	
	update(entity: TEntity): Promise<ResponseResultSet>;
	
	delete(entity: TEntity): boolean;
	
	get(id: number): TEntity;
	
	getAll(): TEntity[];
}