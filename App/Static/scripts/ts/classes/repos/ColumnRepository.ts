import {IRepository} from "./IRepository";
import {ColumnEntity} from "../entities/ColumnEntity";
import {RepositoryBase} from "./RepositoryBase";

export class ColumnRepository
{
	add(entity: ColumnEntity): boolean
	{
		return true;
	}
	
	delete(entity: ColumnEntity): boolean
	{
		return false;
	}
	
	get(id: number): ColumnEntity
	{
		return undefined;
	}
	
	getAll(): ColumnEntity[]
	{
		return [];
	}
	
	update(entity: ColumnEntity): boolean
	{
		return true;
	}
}