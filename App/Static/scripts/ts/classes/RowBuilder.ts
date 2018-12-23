import {Row} from "./Row";

export class RowBuilder
{
	private static _body;
	
	public create(name: string): Row
	{
		const html = this.getBody().trim();
		
		return new Row($(html));
	}
	
	private getBody(): string
	{
		if (RowBuilder._body !== undefined)
		{
			return RowBuilder._body;
		}
		
		RowBuilder._body = $.ajax(
			{
				url: 'partials/getrowhtml',
				method: "GET",
				async: false
			}
		).responseText;
		
		return RowBuilder._body;
	}
}