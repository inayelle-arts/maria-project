export interface IRepository<TEntity>
{
	add(entity: TEntity): boolean;
	
	update(entity: TEntity): boolean;
	
	delete(entity: TEntity): boolean;
	
	get(id: number): TEntity;
	
	getAll(): TEntity[];
}