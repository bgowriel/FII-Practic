import { outputAst } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  @Output() currentPage: number = 1;
  @Output() itemsPerPage: number = 10;
  @Input() itemsTotalCount!: number;
  @Output() pageEvent = new EventEmitter<PageEvent>();

  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.paginator.length = this.itemsTotalCount;
    })
    this.paginator.page.subscribe(
      (page) => {
        this.pageEvent.emit({ pageIndex: page.pageIndex, pageSize: page.pageSize, length: page.length });
        this.currentPage = page.pageIndex + 1;
        this.itemsPerPage = page.pageSize;
      }
    )
  }

  ngOnChanges() {
    setTimeout(() => {
      this.paginator.length = this.itemsTotalCount;
    })
  }
}
