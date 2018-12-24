import {BoardUnit} from "./units/BoardUnit";
import {BoardEntity} from "./entities/BoardEntity";
import {ColumnEntity} from "./entities/ColumnEntity";
import {TaskEntity} from "./entities/TaskEntity";

export class BoardController
{
	private static readonly BoardId: string = 'board';
	
	private _board: BoardUnit;
	
	public initialize(): void
	{
		
	}
	
	public testInitialize(): void
	{
		localStorage.clear();
		
		const tasks1 = new Array<TaskEntity>();
		tasks1.push(
			new TaskEntity(1, 'task1', 'desc1', '#1'),
			new TaskEntity(2, 'task2', 'desc2', '#2'),
			new TaskEntity(3, 'task3', 'desc3', '#3')
		);
		
		const cols1 = new Array<ColumnEntity>();
		cols1.push(
			new ColumnEntity(1, 'colFIRST', tasks1),
			new ColumnEntity(1, 'colLAST', tasks1)
		);
		
		const eBoard = new BoardEntity(1, 'topkek', cols1);
		
		this._board = new BoardUnit(eBoard);
		
		this._board.addColumn('kek');
	}
}