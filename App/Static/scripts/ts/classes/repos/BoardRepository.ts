import {BoardEntity} from "../entities/BoardEntity";
import {RepositoryBase} from "./RepositoryBase";
import {ErrorModalComponent} from "../components/modals/ErrorModalComponent";

export class BoardRepository
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
	
	async getAsync(id: number): Promise<BoardEntity>
	{
		const json = await $.get(
			{
				url: BoardRepository.Uri + id,
				dataType: "json",
				async: false
			}
		).responseText;
		
		let board: BoardEntity = null;
		
		try
		{
			board = JSON.parse(json) as BoardEntity;
		} catch (e)
		{
			ErrorModalComponent.getInstance().showWithMessage('Data loss. Please, reload the page');
		}
		
		return board;
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