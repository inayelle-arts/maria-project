import {BoardEntity} from "../entities/BoardEntity";
import {RepositoryBase} from "./RepositoryBase";

export class BoardRepository extends RepositoryBase<BoardEntity>
{
	private readonly uri: string = "/board/";
	
	add(entity: BoardEntity): boolean
	{
		return false;
	}
	
	delete(entity: BoardEntity): boolean
	{
		return false;
	}
	
	get(id: number): BoardEntity
	{
		return undefined;
	}
	
	getAll(): BoardEntity[]
	{
		return [];
	}
	
	update(entity: BoardEntity): boolean
	{
		return true;
	}
}