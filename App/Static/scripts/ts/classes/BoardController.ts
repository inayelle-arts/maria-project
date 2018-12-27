import {ContentComponent} from "./components/ContentComponent";
import {BoardUnit} from "./units/BoardUnit";
import {RepositoryManager} from "./repos/RepositoryManager";
import {LoadingModalComponent} from "./components/modals/LoadingModalComponent";
import {UnitManager} from "./units/UnitManager";
import {ErrorModalComponent} from "./components/modals/ErrorModalComponent";

export class BoardController
{
	private static readonly _repoManager = RepositoryManager.getInstance();
	private static readonly _unitManager = UnitManager.getInstance();
	
	private readonly _contentComponent: ContentComponent;
	private readonly _loadingModalComponent: LoadingModalComponent;
	private _boardUnit: BoardUnit;
	
	constructor()
	{
		localStorage.clear();
		this._contentComponent = new ContentComponent('content');
		this._loadingModalComponent = new LoadingModalComponent('loading-modal');
	}
	
	public run(): void
	{
		const promise = this.loadBoardAsync();
		
		promise.catch(console.log);
		
		promise.then((boardUnit: BoardUnit) =>
		{
			BoardController._unitManager.BoardUnit = boardUnit;
			this._boardUnit = boardUnit;
			this._contentComponent.addChild(this._boardUnit.Component);
			this._loadingModalComponent.JDom.hide();
		});
		
		this._loadingModalComponent.show();
		
		ErrorModalComponent.getInstance().showWithMessage('run');
	}
	
	private async loadBoardAsync(): Promise<BoardUnit>
	{
		return await this.loadBoardUnitAsync();
	}
	
	private async loadBoardUnitAsync(): Promise<BoardUnit>
	{
		const entity = await BoardController._repoManager.Board.getAsync(1);
		
		return new BoardUnit(entity);
	}
}