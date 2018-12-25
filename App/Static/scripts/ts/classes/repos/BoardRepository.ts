import {BoardEntity} from "../entities/BoardEntity";
import {RepositoryBase} from "./RepositoryBase";
import {ColumnEntity} from "../entities/ColumnEntity";
import {TaskEntity} from "../entities/TaskEntity";

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
		const tasks = new Array<TaskEntity>();
		
		tasks.push(
			new TaskEntity(1, 'Task1', 'Desc1', '#1'),
			new TaskEntity(2, 'Task2', 'Desc2', '#2'),
			new TaskEntity(3, 'Task3', 'Desc3', '#3'),
			new TaskEntity(4, 'Task4', 'Desc4', '#4'),
		);
		
		const cols = new Array<ColumnEntity>();
		
		cols.push(
			new ColumnEntity(1, 'Column1', tasks),
			new ColumnEntity(2, 'Column2', tasks)
		);
		
		return new BoardEntity(id, 'BOOOOARD', cols);
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