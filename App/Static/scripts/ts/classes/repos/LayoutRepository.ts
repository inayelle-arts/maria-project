export class LayoutRepository
{
	private static readonly LayoutUri = "/layouts/";
	private static readonly TaskLayoutKey = "TaskLayout";
	private static readonly ColumnLayoutKey = "ColumnLayout";
	private static readonly BoardLayoutKey = "BoardLayout";
	
	public get TaskLayout(): string
	{
		return this.loadLayout(LayoutRepository.TaskLayoutKey);
	}
	
	public get ColumnLayout(): string
	{
		return this.loadLayout(LayoutRepository.ColumnLayoutKey);
	}
	
	public get BoardLayout(): string
	{
		return this.loadLayout(LayoutRepository.BoardLayoutKey);
	}
	
	private loadLayout(key: string): string
	{
		if (this.layoutCached(key))
		{
			return this.loadLayoutFromStorage(key);
		}
		
		let layout = this.loadLayoutFromServer(key);
		
		this.cacheLayout(key, layout);
		
		return layout;
	}
	
	private loadLayoutFromServer(key: string): string
	{
		const url = LayoutRepository.LayoutUri + key;
		
		return $.get(
			{
				url: url,
				async: false
			}
		).responseText;
	}
	
	private loadLayoutFromStorage(key: string): string
	{
		return localStorage.getItem(key);
	}
	
	private layoutCached(key: string): boolean
	{
		return this.loadLayoutFromStorage(key) !== null;
	}
	
	private cacheLayout(key: string, value: string): void
	{
		localStorage.setItem(key, value);
	}
}
