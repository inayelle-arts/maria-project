import {MainComponent} from "./components/test/MainComponent";
import {ChildComponent} from "./components/test/ChildComponent";

export class BoardController
{
	constructor()
	{
		localStorage.clear();
	}
	
	public initialize(): void
	{
		
	}
	
	public tester(): void
	{
		const mainComponent = new MainComponent("content");
		
		const child1 = new ChildComponent('1');
		const child2 = new ChildComponent('2');
		
		mainComponent.addChild(child1);
		mainComponent.addChild(child2);
		
		mainComponent.removeChild(child2);
		mainComponent.addChild(child2);
		
		
		// const childComponent1 = new ChildComponent('' + 1);
		// const childComponent2 = new ChildComponent('' + 2);
		
		// mainComponent.addChild(childComponent1);
		// mainComponent.addChild(childComponent2); 
	}
}