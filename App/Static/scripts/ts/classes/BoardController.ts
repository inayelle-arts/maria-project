import {ContentComponent} from "./components/ContentComponent";
import {BoardUnit} from "./units/BoardUnit";
import {RepositoryManager} from "./repos/RepositoryManager";
import {LoadingModalComponent} from "./components/modals/LoadingModalComponent";
import {MoreModalComponent} from "./components/modals/MoreModalComponent";

export class BoardController
{
	private static readonly _repoManager = RepositoryManager.getInstance();
	
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
			console.log('board loaded');
			this._boardUnit = boardUnit;
			this._contentComponent.addChild(this._boardUnit.Component);
			this._loadingModalComponent.hide();
		});
		
		this._loadingModalComponent.show();
	}
	
	private async loadBoardAsync(): Promise<BoardUnit>
	{
		console.log('loadBoard');
		return await this.loadBoardUnitAsync();
	}
	
	private async loadBoardUnitAsync(): Promise<BoardUnit>
	{
		console.log('before getAsync');
		const entity = await BoardController._repoManager.Board.getAsync(1);
		console.log('getAsync done');
		
		console.log(entity.id + "!!!!!!!!");
		
		return new BoardUnit(entity);
	}
}