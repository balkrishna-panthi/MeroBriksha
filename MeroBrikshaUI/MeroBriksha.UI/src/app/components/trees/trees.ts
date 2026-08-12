import { Component } from '@angular/core';
import { TreesService } from '../../core/services/treesServices/trees-service';
import { Observable } from 'rxjs';
import { Tree } from '../../core/models/trees/tree';
import { TreesTable } from "../../widgets/trees-table/trees-table";

@Component({
  selector: 'app-trees',
  imports: [TreesTable],
  templateUrl: './trees.html',
  styleUrl: './trees.css',
})
export class Trees {
  treesList$? : Observable<Tree[]>;

constructor(private treeService : TreesService){

}
ngOnInit(){

  this.treeService.getTrees().subscribe(data=>
  {
    console.log(data);
  }
  );
  this.getTrees();
}
getTrees(){
  this.treesList$ = this.treeService.getTrees();
}
deleteTree(id : string){
  console.log("Delete Tree Clicked!!: " + id);
}


}
