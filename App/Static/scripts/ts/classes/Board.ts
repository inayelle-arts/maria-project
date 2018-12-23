import {ComponentBase} from "./ComponentBase";
import {Row} from "./Row";
import {RowBuilder} from "./RowBuilder";

export class Board extends ComponentBase
{
	private rowBuilder: RowBuilder;
	
	private static readonly HtmlElementId = "#board";
	private static readonly HtmlRowClass = "board-row";
	
	private readonly _rows: Array<Row>;
	
	public constructor()
	{
		super($(Board.HtmlElementId));
		
		this._rows = new Array<Row>();
		
		const rowDoms = this.children(Board.HtmlRowClass);
		
		rowDoms.forEach((rowDom: JQuery<HTMLElement>) =>
		{
			this._rows.push(new Row($(rowDom)));
		});
		
		this.rowBuilder = new RowBuilder();
	}
	
	public createRow(name: string)
	{
		const row = this.rowBuilder.create(name);
	
		this._rows.push(row);
		
		this.dom.append(row.jDom);
	}
}