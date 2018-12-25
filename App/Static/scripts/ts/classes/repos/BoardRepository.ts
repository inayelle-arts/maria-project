import {BoardEntity} from "../entities/BoardEntity";
import {RepositoryBase} from "./RepositoryBase";

export class BoardRepository extends RepositoryBase<BoardEntity>
{
	private static readonly Uri: string = "http://localhost:8765/api/board/";
	
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
		const json = $.get(
			{
				url: BoardRepository.Uri + id,
				dataType: "json",
				async: false
			}
		).responseText;
		
		return JSON.parse(json) as BoardEntity;
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