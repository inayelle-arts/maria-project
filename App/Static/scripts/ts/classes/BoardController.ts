import {ContentComponent} from "./components/ContentComponent";
import {BoardUnit} from "./units/BoardUnit";
import {RepositoryManager} from "./repos/RepositoryManager";

export class BoardController
{
	private static readonly _repoManager = RepositoryManager.getInstance();
	
	private readonly _contentComponent: ContentComponent;
	private readonly _boardUnit: BoardUnit;
	
	constructor()
	{
		localStorage.clear();
		this._contentComponent = new ContentComponent('content');
		this._boardUnit = BoardController.loadBoardUnit();
	}
	
	public initialize(): void
	{
		this._contentComponent.addChild(this._boardUnit.Component);
	}
	
	private static loadBoardUnit(): BoardUnit
	{
		const entity = this._repoManager.Board.get(1);
		
		return new BoardUnit(entity);
	}
}