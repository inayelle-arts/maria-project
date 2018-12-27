import {BoardRepository} from "./BoardRepository";
import {ColumnRepository} from "./ColumnRepository";
import {TaskRepository} from "./TaskRepository";

export class RepositoryManager
{
	private static __instance__ = null;
	
	private readonly _boardRepo: BoardRepository;
	private readonly _columnRepo: ColumnRepository;
	private readonly _taskRepo: TaskRepository;
	
	protected constructor()
	{
		this._boardRepo = new BoardRepository();
		this._columnRepo = new ColumnRepository();
		this._taskRepo = new TaskRepository(this);
	}
	
	get Board(): BoardRepository
	{
		return this._boardRepo;
	}
	
	get Column(): ColumnRepository
	{
		return this._columnRepo;
	}
	
	get Task(): TaskRepository
	{
		return this._taskRepo;
	}
	
	public static getInstance(): RepositoryManager
	{
		if (this.__instance__ == null)
		{
			this.__instance__ = new RepositoryManager();
		}
		
		return this.__instance__;
	}
}